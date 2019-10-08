using RBS_YDLidarSerial;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TestTelaCloudPoint
{

    public partial class Form1 : Form
    {

        CommSerial comm = new CommSerial();
        Bitmap bitmap;
        int[,] matriz = new int[20000,20000];
        int OrigemMatrizX = 10000, OrigemMatrizY = 10000;
        static bool finalizado1 = false;
        
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            matriz.Initialize();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            comm.Conectar(txtPorta.Text);
            comm.SendStartScan();
            timerPontosNaTela.Start();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (comm.Conectado)
                comm.Desconectar();
            timerPontosNaTela.Stop();
        }

        private void timerPontosNaTela_Tick(object sender, EventArgs e)
        {
            
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comm.Conectado && pictureBox.Width > 0)
            {
                Graphics GR;
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                int origemX = bitmap.Width / 2;
                int origemY = bitmap.Height / 2;
                float razaoX = (float) origemX / OrigemMatrizX;
                float razaoY = (float) origemY / OrigemMatrizY;

                for (int i = 0; i < 20000; i++)
                {
                    for (int j = 0; j < 20000; j++)
                    {
                        matriz[i, j] = 0;
                    }
                }

                pictureBox.Image = bitmap;

                foreach (var ponto in comm.pontos)
                {
                    if (ponto != null)
                    {
                        if (ponto.Distancia > 0 && !ponto.lido)
                        {
                            ponto.lido = true;
                            float x = (float)(Convert.ToDouble(ponto.Distancia) * Math.Sin(ConvertToRadians(Convert.ToDouble(ponto.Angulo)))) + OrigemMatrizX;
                            float y = (float)(Convert.ToDouble(ponto.Distancia) * Math.Cos(ConvertToRadians(Convert.ToDouble(ponto.Angulo)))) + OrigemMatrizY;
                            matriz[(int)Math.Round(x), (int)Math.Round(y)] = 1;
                        }
                    }
                }
                
                using (GR = Graphics.FromImage(bitmap))
                {
                    GR.FillEllipse(new SolidBrush(Color.Red), origemX, origemY, 5, 5);
                    for (int x = 0; x < 20000; x++)
                    {
                        for (int y = 0; y < 20000; y++)
                        {
                            if (matriz[x, y] == 1)
                            {
                                GR.FillEllipse(new SolidBrush(Color.Black), x * razaoX, y * razaoY, 5, 5);
                            }
                        }
                    }
                }
            }

            pictureBox.Image = bitmap;
        }

    }
}
