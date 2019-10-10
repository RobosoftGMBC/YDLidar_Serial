using RBS_YDLidarSerial;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TestTelaCloudPoint
{

    public partial class Form1 : Form
    {
        List<Coordenada> coordenadas = new List<Coordenada>();
        CommSerial comm = new CommSerial();
        Bitmap bitmap;
        int[,] matriz = new int[4000, 4000];
        int OrigemMatrizX = 2000, OrigemMatrizY = 2000;
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
                float razaoX = (float)origemX / OrigemMatrizX;
                float razaoY = (float)origemY / OrigemMatrizY;

                foreach (Coordenada coordenada in coordenadas)
                {
                    matriz[coordenada.x, coordenada.y] = 0;

                }
                coordenadas.Clear();

                //pictureBox.Image = bitmap;

                for (int i = 0; i < 3000; i++)
                {
                    Ponto ponto = comm.pontos[i];
                    if (ponto != null)
                    {
                        if (ponto.Distancia > 0 && !ponto.lido)
                        {
                            ponto.lido = true;
                            float x = (float)(Convert.ToDouble(ponto.Distancia / 5) * Math.Sin(ConvertToRadians(Convert.ToDouble(ponto.Angulo)))) + OrigemMatrizX;
                            float y = (float)(Convert.ToDouble(ponto.Distancia / 5) * Math.Cos(ConvertToRadians(Convert.ToDouble(ponto.Angulo)))) + OrigemMatrizY;
                            if (x < 0)
                                x = 0;

                            if (x > 4000)
                                x = 4000;

                            if (y < 0)
                                y = 0;

                            if (y > 4000)
                                y = 4000;

                            matriz[(int)Math.Round(x), (int)Math.Round(y)] = 1;
                            Coordenada c = new Coordenada((int)Math.Round(x), (int)Math.Round(y), (int)(x * razaoX - origemX), (int)(y * razaoY - origemY),ponto.Angulo, ponto.Distancia);
                            coordenadas.Add(c);

                        }
                    }
                }

                using (GR = Graphics.FromImage(bitmap))
                {

                    foreach (Coordenada coordenada in coordenadas)
                    {


                        Bresenham(GR, origemX, origemY, (int)((float)coordenada.x * razaoX), (int)((float)coordenada.y * razaoY)); ;

                        GR.FillEllipse(new SolidBrush(Color.Black), coordenada.x* razaoX, coordenada.y * razaoY, 5, 5);
                    }

                    GR.FillEllipse(new SolidBrush(Color.Red), origemX, origemY, 5, 5);
                }
            }

            pictureBox.Image = bitmap;
        }
        int sign(int v)
        {
            return v > 0 ? 1 : ((v < 0) ? -1 : 0);
        }

        int abs(int x)
        {
            return x > 0 ? x : -x;
        }

        int max(int a, int b)
        {
            return a > b ? a : b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Mapa mapa = new Mapa();
            int[,] matriz = mapa.CarregarMapa();
            Graphics GR;

            using (GR = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < 4500; i++)
                {
                    for (int j = 0; j < 4000; j++)
                    {
                        if (matriz[i, j] == 1)
                            GR.FillRectangle(new SolidBrush(Color.Blue), i / 10 + bitmap.Width / 2 - 200, j / 10 + bitmap.Height / 2 - 225, 5, 5);
                    }
                }

            }

            pictureBox.Image = bitmap;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int xrandon, yrandon;
            int angulorandon, cordenadax, cordenaday;
            float angulo, distancia;
            matriz = new int[100, 3]; 
            Graphics GR;
            using (GR = Graphics.FromImage(bitmap))
               
            {


                Random randon = new Random();
                for (int i = 0; i < 100; i++)
                {
                    xrandon = randon.Next(0,4499);
                    matriz[i, 0] = xrandon;
                    yrandon = randon.Next(0,3999);
                    matriz[i, 1] = yrandon;
                    angulorandon = randon.Next(360);
                    matriz[i, 2] = angulorandon;
                    GR.FillEllipse(new SolidBrush(Color.DarkGreen), xrandon / 10 + bitmap.Width / 2 - 200, yrandon / 10 + bitmap.Height / 2 - 225, 5, 5);
                    for (int j = 0; j < 3000; j++)
                    {
                        
                    }
               
                }


            }

        }
     
        private void Bresenham(Graphics gr, int x1, int y1, int x2, int y2)
        {
            int deltaX = x2 - x1;
            int deltaRow = abs(deltaX);
            int rowInc = sign(deltaX);

            int deltaY = y2 - y1;
            int deltaCol = abs(deltaY);
            int colInc = sign(deltaY);

            int rowAccum = 0;
            int colAccum = 0;
            int rowCursor = x1;
            int colCursor = y1;

            int counter = max(deltaCol, deltaRow);
            int endPnt = counter;
            if (counter == deltaCol)
            {
                rowAccum = endPnt / 2;
                for (; counter > 0; --counter)
                {
                    rowAccum += deltaRow;
                    if (rowAccum >= endPnt)
                    {
                        rowAccum -= endPnt;
                        rowCursor += rowInc;
                    }

                    colCursor += colInc;
                    gr.FillEllipse(new SolidBrush(Color.LightGray), rowCursor, colCursor, 5, 5);
                }

            }
            else
            {
                colAccum = endPnt / 2;
                for (; counter > 0; --counter)
                {
                    colAccum += deltaCol;
                    if (colAccum > endPnt)
                    {
                        colAccum -= endPnt;
                        colCursor += colInc;
                    }
                    rowCursor += rowInc;
                    gr.FillEllipse(new SolidBrush(Color.LightGray), rowCursor, colCursor, 5, 5);
                }
            }



        }


        public class Coordenada
        {
            public int x, y;
            public int p, dx, dy; //algoritimo de bresenham
            public float angulo, distancia;
            public Coordenada(int x, int y, int dx, int dy,float angulo, float distancia)
            {
                this.x = x;
                this.y = y;

                this.dx = dx;
                this.dy = dy;
                this.angulo = angulo;
                this.distancia = distancia;

            }
        }
        

    }
}
