using RBS_YDLidarSerial;
using System;
using System.Collections.Generic;
using System.Drawing;
using TestTelaCloudPoint.Models;
using TestTelaCloudPoint.Models.Statics;

namespace TestTelaCloudPoint.Controllers
{
    class Controller
    {
        CommSerial comm = new CommSerial();

        public Bitmap BuscarMapaFisico(int Width, int Height)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            MapaFisico mapa = new MapaFisico();

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

            return bitmap;
        }

        internal bool LiddarConectado()
        {
            return comm.Conectado;
        }

        internal void DesconectarLiddar()
        {
            if (comm.Conectado)
                comm.Desconectar();
        }

        internal void ConectarLiddar(string porta)
        {
            comm.Conectar(porta);
            comm.SendStartScan();
        }

        public Bitmap BuscarMapaLiddar(int Width, int Height)
        {
            MapaLiddar mapaLiddar = new MapaLiddar();
            List<Coordenada> coordenadas = mapaLiddar.BuscarCoordenadasLidar(comm.pontos, 2000, 2000);
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics GR;

            int origemX = Width / 2;
            int origemY = Height / 2;
            float razaoX = 1;   //(float)origemX / OrigemMatrizX;
            float razaoY = 1;   //(float)origemY / OrigemMatrizY;

            using (GR = Graphics.FromImage(bitmap))
            {
                for (int h = 0; h < coordenadas.Count; h++)
                {

                    Coordenada coordenada = coordenadas[h];

                    GR.DrawLine(new Pen(Color.Silver), origemX, origemY, coordenada.x / 10 + origemX, coordenada.y /  10 + origemY);
                    //Pinta os pontos intermediarios até a coordenada
                    //int[,] matrizBresenham = Bresenham.Run(origemX, origemY, (int)((float)coordenada.x), (int)((float)coordenada.y));
                    //for (int i = 0; i < Math.Sqrt(matrizBresenham.Length); i+=100)
                    //{
                    //   GR.FillRectangle(new SolidBrush(Color.Silver), matrizBresenham[i, 0]+origemX, matrizBresenham[i, 1]+origemY, 1, 1);
                    //}

                    //Pinta a coordenada
                    GR.FillRectangle(new SolidBrush(Color.Black), coordenada.x/10+origemX, coordenada.y/10+origemY, 2, 2);
                }

                //Pinta a origem da coordenada
                GR.FillEllipse(new SolidBrush(Color.Red), origemX, origemY, 10, 10);
            }

            return bitmap;
        }

        public Bitmap BuscarMapaAleatorio(int Width, int Height)
        {
            Graphics GR;
            Bitmap bitmap = new Bitmap(Width, Height);
            Localization localization = new Localization();

            List<int[,]> pontosAleatorios = localization.GerarPontosRandomicos(4500, 4000, 100); // gera uma lista de vetores com 3 dimensoes

            //Plotar os pontos no bitmap
            using (GR = Graphics.FromImage(bitmap))
            {
                foreach (var ponto in pontosAleatorios)
                {
                    int x = ponto[0, 0];
                    int y = ponto[0, 1];
                    int ang = ponto[0, 2];
                    int tamanholinha = 15;
                    //gera o segundo ponto
                    float x2= (float)Math.Sin(ang) * tamanholinha + x / 10 + bitmap.Width / 2 - 100;
                    float y2= (float)Math.Cos(ang) * tamanholinha + y / 10 + bitmap.Height / 2 - 125;
                    //plota os pontos aleatorios e as linhas aleatorias
                    GR.FillEllipse(new SolidBrush(Color.DarkGreen), x / 10 + bitmap.Width / 2 -100, y / 10 + bitmap.Height / 2 - 125, 5, 5);
                    GR.DrawLine(new Pen(Color.Black), x / 10 + bitmap.Width / 2 - 100, y / 10 + bitmap.Height / 2 - 125, (int)Math.Round(x2), (int)Math.Round(y2));
                }
            }

            return bitmap;
        }
    }
}
