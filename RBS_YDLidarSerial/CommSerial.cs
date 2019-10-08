using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Management;

namespace RBS_YDLidarSerial
{
    public enum Tipo { Scan, PointCloud, InfoModelo, Health };
    public enum Modo { Continuo, Single, Undefined};

    public static class Utilidades
    {
        public static byte StringToByte(string s)
        {
            return Convert.ToByte("0x5D", 16);
        }

        public static string ByteToString(byte b)
        {
            string aux = b.ToString("X");
            if (aux.Length < 2)
                aux = "0" + aux;
            return aux;
        }
        public static int HexStringToInt(string s)
        {
            return int.Parse(s, System.Globalization.NumberStyles.HexNumber);
        }

        public static float HexStringToFloat(string s)
        {
            return (float) (int.Parse(s, System.Globalization.NumberStyles.HexNumber));
        }

        public static string StringIntToHexString(string s)
        {
            return Convert.ToInt32(s).ToString("X");
        }


        public static string ShiftRightString(string s, int qnt)
        {
            byte aux = StringToByte(s);
            int auxint = aux >> qnt;
            return StringIntToHexString(auxint.ToString());
        }

        public static bool Checksum(List<string> data, int checksum)
        {
            int C = Utilidades.HexStringToInt(data[8]) + (Utilidades.HexStringToInt(data[9]) << 8);
            int dataCheckSum = Utilidades.HexStringToInt(data[0]) + (Utilidades.HexStringToInt(data[1]) << 8);
            dataCheckSum ^= Utilidades.HexStringToInt(data[4]) + (Utilidades.HexStringToInt(data[5]) << 8);
            for (int i = 0; i < Utilidades.HexStringToInt(data[3]); i++)
            {
                dataCheckSum ^= Utilidades.HexStringToInt(data[i * 2 + 10]) + (Utilidades.HexStringToInt(data[i * 2 + 11]) << 8);
            }
            dataCheckSum ^= Utilidades.HexStringToInt(data[2]) + (Utilidades.HexStringToInt(data[3]) << 8);
            dataCheckSum ^= Utilidades.HexStringToInt(data[6]) + (Utilidades.HexStringToInt(data[7]) << 8);
            return dataCheckSum == checksum;
        }
    }

    public class Ponto
    {
        public int IdLeitura;
        public float Angulo;
        public float Distancia;
        public bool lido = false;
    }

    public class Mensagem
    {
        public Tipo tipo;
        public string Firmware;
        public string HardwareVersion;
        public string Model;
        public string HealthStatus;
        public string SerialNumber;

        Queue<Ponto> pontos = new Queue<Ponto>();
        List<string> conteudo;

        public Mensagem(Tipo tipoMensagem, List<string> conteudo)
        {
            tipo = tipoMensagem;
            this.conteudo = conteudo;
            OrganizarConteudo();
        }

        private void OrganizarConteudo()
        {
            switch (tipo)
            {
                case Tipo.PointCloud:
                    OrganizaCloudPoint();
                    break;
                case Tipo.InfoModelo:
                    OrganizaInfoDevice();
                    break;
                case Tipo.Health:
                    OrganizaHealth();
                    break;
                default:
                    break;
            }
        }

        private void OrganizaHealth()
        {
            switch (conteudo[7])
            {
                case "00":
                    HealthStatus = "Normal";
                    break;
                case "01":
                    HealthStatus = "Normal";
                    break;
                case "02":
                    HealthStatus = "Erro codigo: 0x" + conteudo[8] + ", 0x" + conteudo[9];
                    break;
                default:
                    HealthStatus = "...";
                    break;
            }

        }

        private void OrganizaInfoDevice()
        {
            //Modelo
            if (conteudo[6] == "04")
                Model = "X4";
            else
                Model = "Nao cadastrado";

            //Firmware
            Firmware = Convert.ToInt32(conteudo[8]).ToString() + "." + Convert.ToInt32(conteudo[7]);


            HardwareVersion = conteudo[9];
            //Serial number
            SerialNumber = "";
            for (int i = 11; i < 27; i++)
            {
                SerialNumber += conteudo[i];
            }

        }

        private void OrganizaCloudPoint()
        {
            int qntPontos = Utilidades.HexStringToInt(conteudo[3]);
            bool pointCloud = conteudo[2] == "00";
            int fsa = Utilidades.HexStringToInt(conteudo[5] + conteudo[4]);
            int lsa = Utilidades.HexStringToInt(conteudo[7] + conteudo[6]);
            float dist1 = Distancia(1);
            float distLsn = Distancia(qntPontos);
            float StartAngleFSA = ((fsa >> 1) / 64.0F) + AngleCorrect(dist1);  //in deg
            float EndAngleLSA = ((lsa >> 1) / 64.0F) + AngleCorrect(distLsn);	//in deg

            float distancia = 0f;
            float angulo = 0f;

            if (pointCloud)
            {
                float diffAngle;
                if (StartAngleFSA > EndAngleLSA)
                {
                    diffAngle = EndAngleLSA + 360.0F - StartAngleFSA;
                }
                else
                {
                    diffAngle = EndAngleLSA - StartAngleFSA;
                }

                for (int i = 2; i < (qntPontos - 1); i++)
                {
                    distancia = Distancia(i);    //in mm
                    angulo = (diffAngle / (qntPontos - 1)) * (i - 1) + StartAngleFSA + AngleCorrect(distancia);    //in deg
                    if (angulo < 0.0F)
                    {
                        angulo = 360.0f - angulo;
                    }

                    Ponto p = new Ponto();
                    p.Distancia = distancia;
                    p.Angulo = angulo;
                    pontos.Enqueue(p);
                }
            }
        }

        private float Distancia(int index)
        {
            index -= 1;
            return Utilidades.HexStringToFloat(conteudo[index * 2 + 11] + conteudo[index * 2 + 10]) / 4f;
        }

        private float AngleCorrect(float dist)
        {
            if (dist > 0)
                return (float)(Math.Atan(21.8F * ((155.3F - dist) / (155.3F * dist))) / Math.PI * 180.0F);
            else
                return 0f;
        }

        public List<Ponto> GetPointCloud()
        {
            return pontos.ToList();
        }

        public Ponto GetNexPoint()
        {
            return pontos.Dequeue();
        }

        public List<string> GetData()
        {
            return conteudo;
        }
    }

    public class UnmountReadSerial
    {
        public Queue<Mensagem> FilaMensagens = new Queue<Mensagem>();
        private List<string> sobrei = new List<string>();

        public void DecodificarMensagem(byte[] leituraSerial)
        {
            List<List<string>> mensagens = SepararMensagens(leituraSerial);

            foreach (var mensagem in mensagens)
            {
                Mensagem m = new Mensagem(IdentificarTipoMensagem(mensagem), mensagem);
                FilaMensagens.Enqueue(m);
            }
        }

        private List<List<string>> SepararMensagens(byte[] leituraSerial)
        {

            List<string> serial = new List<string>();

            serial.AddRange(sobrei);
            sobrei.Clear();
            
            List<List<string>> mensagens = new List<List<string>>();

            //Cria uma lista com a mensagem convertida 
            for (int i = 0; i < leituraSerial.Length; i++)
            {
                serial.Add(Utilidades.ByteToString(leituraSerial[i]));
            }

            bool comMensagem = true;
            while (comMensagem)
            {
                List<string> mensagem = new List<string>(RemoveMensagem(ref serial));
                
                comMensagem = mensagem.Count > 0;
                if (comMensagem)
                {
                    mensagens.Add(mensagem);
                }
                else if (serial.Count > 0)
                    sobrei = serial.ToList();
            }

            return mensagens;
        }

        //Remove a primeira mensagem da serial
        private List<string> RemoveMensagem(ref List<string> serial)
        {
            //A mensagem inicia com 0XA55A
            List<string> auxS = new List<string>();
            int inicioMensagem = InicioMensagem(serial);
            int tamanhoMensagem = -1;
            bool tamanhoMensagemValido = false;
            bool checkSumOk = true;
            Tipo tipoMensagem;

            if (inicioMensagem >= 0) //Encontrou um inicio
            {
                if (serial.Count > inicioMensagem + 8)
                {
                    tipoMensagem = IdentificarTipoMensagem(serial.GetRange(inicioMensagem, 7));

                    switch (tipoMensagem)
                    {
                        case Tipo.Scan:
                            tamanhoMensagem = 10;
                            break;
                        case Tipo.PointCloud:
                            tamanhoMensagem = Utilidades.HexStringToInt(serial[inicioMensagem + 3]) * 2 + 10;
                            break;
                        case Tipo.InfoModelo:
                            tamanhoMensagem = 10;
                            break;
                        case Tipo.Health:
                            tamanhoMensagem = 10;
                            break;
                        default:
                            break;
                    }
                    tamanhoMensagemValido = (serial.Count + inicioMensagem) >= (tamanhoMensagem);

                    
                    if (tamanhoMensagemValido && (tipoMensagem == Tipo.PointCloud))
                        checkSumOk = Utilidades.Checksum(serial.GetRange(inicioMensagem, serial.Count - inicioMensagem), Utilidades.HexStringToInt(serial[inicioMensagem + 9] + serial[inicioMensagem + 8]));

                    if (tamanhoMensagemValido && checkSumOk)
                    {
                        if (tipoMensagem == Tipo.PointCloud)
                            auxS = serial.GetRange(inicioMensagem, tamanhoMensagem); //Recorta a mensagem

                        if (serial.Count() > tamanhoMensagem)
                        {
                            serial = serial.GetRange(inicioMensagem + tamanhoMensagem, serial.Count - (inicioMensagem + tamanhoMensagem));
                            return auxS;
                        }
                        else
                        {
                            serial.Clear();
                            return auxS;
                        }
                    }
                    else if (!checkSumOk)
                    {
                        serial.RemoveRange(0, 2);
                    }

                }                
            }
            return auxS;
        }


        private Tipo IdentificarTipoMensagem(List<string> mensagem)
        {
            if (mensagem[0] == "AA")
                return Tipo.PointCloud;

            switch (mensagem[6])    
            {
                case "81":
                    return Tipo.Scan;
                case "04":
                    return Tipo.InfoModelo;
                case "06":
                    return Tipo.Health;
                default:
                    break;
            }
            return Tipo.Scan;

        }

        private int InicioMensagem(List<string> serial)
        {
            for (int i = 0; i < serial.Count - 1; i++)
            {
                if (serial[i] == "A5")
                {
                    if (serial.Count >= i + 1)
                    {
                        if (serial[i + 1] == "5A")
                        {
                            return i;
                        }

                    }
                }else if (serial[i] == "AA")
                {
                    if (serial.Count >= i + 1)
                    {
                        if (serial[i + 1] == "55")
                        {
                            return i;
                        }

                    }
                }
            }
            return -1;
        }

    }

    public class MountWriteSerial
    {
        const byte START = 0xA5;
        const byte SCAN_MODE = 0x60;
        const byte STOP_MODE = 0x65;
        const byte GET_DEVICE_INFO = 0x90;
        const byte GET_DEVICE_HEALTH = 0x91;
        const byte SOFT_REBOOT = 0x40;

        public byte[] GetDeviceInformation()
        {
            byte[] mensagem = { START, GET_DEVICE_INFO };
            return mensagem;
        }

        public byte[] GetHealthStatus()
        {
            byte[] mensagem = { START, GET_DEVICE_HEALTH };
            return mensagem;
        }

        public byte[] StopScan()
        {
            byte[] mensagem = { START, STOP_MODE };
            return mensagem;
        }

        public byte[] SoftReboot()
        {
            byte[] mensagem = { START, SOFT_REBOOT };
            return mensagem;
        }

        public byte[] StartScann()
        {
            byte[] mensagem = { START, SCAN_MODE };
            return mensagem;
        }
    }

    public class CommSerial
    {
        //Variaveis publicas
        public List<string> ydLidarDisponiveis { get => listarPortas(); }
        public string Modelo = "";
        public string Firmware = "";
        public string VersaoHardware = "";
        public string Health = "";
        public Modo modoOperacao = Modo.Single;
        public Ponto[] pontos = new Ponto[3000];
        private int idPonto = 0;
        public bool Conectado { get => serialPort.IsOpen; }

        //Variaveis privadas
        private SerialPort serialPort = new SerialPort();
        private int baudRate = 128000;
        private MountWriteSerial montarSerial = new MountWriteSerial();
        private UnmountReadSerial desmontarSerial = new UnmountReadSerial();

        public CommSerial()
        {
            pontos.Initialize();
        }

        private void ReadSerial(object sender,SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int qntBytes = sp.BytesToRead;
            if (qntBytes >= 10)
            {
                byte[] mensagem = new byte[qntBytes];
                sp.Read(mensagem, 0, qntBytes);

                if (mensagem.Length > 0)
                {
                    desmontarSerial.DecodificarMensagem(mensagem);
                }

                while (desmontarSerial.FilaMensagens.Count > 0)
                {
                    OrganizarMensagem(desmontarSerial.FilaMensagens.Dequeue());
                }
            }
        }

        private void OrganizarMensagem(Mensagem m)
        {
            switch (m.tipo)
            {
                case Tipo.PointCloud:
                    foreach(Ponto p in m.GetPointCloud())
                    {
                        if (idPonto >= 3000)
                            idPonto = 0;
                        p.IdLeitura = idPonto++;
                        pontos[p.IdLeitura] = p;
                    }
                    break;
                case Tipo.InfoModelo:
                    Firmware = m.Firmware;
                    VersaoHardware = m.HardwareVersion;
                    Modelo = m.Model;
                    string SerialNumber = m.SerialNumber;
                    break;
                case Tipo.Health:
                    Health = m.HealthStatus;
                    break;
            }
        }

        public bool Conectar(string portaComm)
        {
            listarPortas(); //lista a porta
            List<string> portas = SerialPort.GetPortNames().ToList();

            if (!portas.Contains(portaComm))
                throw new Exception("Nao é possivel conectar na porta especificada. Nome da porta: " + portaComm);

            try
            {
                //Configuracao da porta
                serialPort.PortName = portaComm;
                serialPort.BaudRate = baudRate;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;

                // Timeout
                serialPort.ReadTimeout = 1000;
                serialPort.WriteTimeout = 1000;

                serialPort.Open();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(ReadSerial);

                BuscarInformacoesLidar();
            }
            catch (Exception e)
            {
                throw new Exception("Houve um problema ao conectar com o dispositivo: " + e.Message);
            }

            return true;
        }

        private void BuscarInformacoesLidar()
        {
            byte[] gi = montarSerial.GetDeviceInformation();

            if (serialPort.IsOpen)
                serialPort.Write(gi, 0, gi.Length);
        }

        public void Desconectar()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        public void SendInfo()
        {
            BuscarInformacoesLidar();
        }

        private List<string> listarPortas()
        {
            List<string> ydLidardevice = new List<string>();
            foreach (var serialName in SerialPort.GetPortNames())
            {

                ManagementClass processClass = new ManagementClass("Win32_PnPEntity");

                ManagementObjectCollection Ports = processClass.GetInstances();
                foreach (ManagementObject property in Ports)
                {
                    if (property.GetPropertyValue("Name") != null)
                        if (property.GetPropertyValue("Name").ToString().Contains("USB") &&
                            property.GetPropertyValue("Name").ToString().Contains("COM") &&
                            property.GetPropertyValue("Name").ToString().Contains("Silicon Labs"))
                        {
                            ydLidardevice.Add(property.GetPropertyValue("Name").ToString());
                        }
                }
            }

            return ydLidardevice;

        }

        public void SendHealth()
        {
            byte[] gi = montarSerial.GetHealthStatus();

            if (serialPort.IsOpen)
                serialPort.Write(gi, 0, gi.Length);
        }

        public void SendSoftReboot()
        {
            byte[] gi = montarSerial.SoftReboot();

            if (serialPort.IsOpen)
                serialPort.Write(gi, 0, gi.Length);
        }

        public void SendStartScan()
        {
            serialPort.DtrEnable = true;
            byte[] gi = montarSerial.StartScann();

            if (serialPort.IsOpen)
                serialPort.Write(gi, 0, gi.Length);
        }

        public void SendStopScan()
        {
            serialPort.DtrEnable = false;
            byte[] gi = montarSerial.StopScan();

            if (serialPort.IsOpen)
                serialPort.Write(gi, 0, gi.Length);
        }
        
        ~CommSerial()
        {
            Desconectar();
        }

    }
}
