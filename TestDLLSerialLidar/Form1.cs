using RBS_YDLidarSerial;
using System;
using System.Windows.Forms;

namespace TestDLLSerialLidar
{
    public partial class Form1 : Form
    {
        CommSerial commSerial;
        public Form1()
        {
            InitializeComponent();
            commSerial = new CommSerial();
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            foreach (var item in commSerial.ydLidarDisponiveis)
            {
                rtResultado.AppendText(item + Environment.NewLine);
            }
            
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            if (!txtPortaCom.Text.Contains("COM"))
            {
                AddLog("Digite a porta COM");
                return;
            }

            AddLog("Estabelecendo conexao");
            try
            {
                commSerial.Conectar(txtPortaCom.Text);
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                AddLog("Conectado");

                timerAtualiza.Start();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                AddLog("Houve um problema ao conectar");
            }
        }

        private void AddLog(string log)
        {
            rtResultado.AppendText(log + Environment.NewLine);
        }

        private void BtnDesconectar_Click(object sender, EventArgs e)
        {
            AddLog("Dispositivo desconectado");
            if (commSerial.Conectado)
                commSerial.Desconectar();

            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            timerAtualiza.Stop();
        }

        private void BtnEnviaInfo_Click(object sender, EventArgs e)
        {
            AddLog("Solicitado informacoes do dispositivo");

            if (commSerial.Conectado)
                commSerial.SendInfo();
        }

        private void BtnEnviaHealth_Click(object sender, EventArgs e)
        {
            AddLog("Solicitado status de vida do dispositivo");
            if (commSerial.Conectado)
                commSerial.SendHealth();
        }

        private void BtnEnviaSoftReboot_Click(object sender, EventArgs e)
        {
            AddLog("Enviado comando de soft reboot");
            if (commSerial.Conectado)
                commSerial.SendSoftReboot();
        }

        private void BtnEnviaStartScan_Click(object sender, EventArgs e)
        {
            AddLog("Enviado comando de start do scan para o dispositivo");
            if (commSerial.Conectado)
                commSerial.SendStartScan();
        }

        private void BtnEnviaStopScan_Click(object sender, EventArgs e)
        {
            AddLog("Enviado comando de stop do scan para o dispositivo");
            if (commSerial.Conectado)
                commSerial.SendStopScan();
        }

        private void TimerAtualiza_Tick(object sender, EventArgs e)
        {
            if (commSerial.Conectado)
            {
                lblFirmware.Text = commSerial.Firmware;
                lblHardwareVersion.Text = commSerial.VersaoHardware;
                lblModelo.Text = commSerial.Modelo;
                lblHealthStatus.Text = commSerial.Health;


            }
        }
    }
}
