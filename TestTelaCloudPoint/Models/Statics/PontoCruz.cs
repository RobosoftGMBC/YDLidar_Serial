using RBS_YDLidarSerial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTelaCloudPoint.Models.Statics
{ 


    static class PontoCruz
    {

        //Roda o algoritmo do ponto cruz
        public static List<Coordenada> Run(List<int[,]> pontosAleatorios, List<Ponto> pontosLiddar)
        {
            List<Ponto> coordenadasEncontradas = new List<Ponto>();
            ///Aqui deve ser implementado a logica do quadro

            foreach (int[,] pontoAleatorio in pontosAleatorios)
            {
                var pontosAng0 = BuscarParadeAng0(pontoAleatorio, pontosLiddar);
                GeraDefasagemAngulo(); //aqui gera a defasagem
                var pontosAng90 = BuscarParadeAng90(pontoAleatorio, pontosAng0);
                var pontosAng180 = BuscarParadeAng180(pontoAleatorio, pontosAng0);
                coordenadasEncontradas = BuscarParadeAng270(pontoAleatorio, pontosAng180);
            }

            return coordenadasEncontradas;
        }

        public static List<Ponto> BuscarParadeAng0(int[,] pontoAleatorio, List<Ponto> pontosLiddar)
        {

        }

        public static List<Ponto> BuscarParadeAng90(int[,] pontoAleatorio, List<Ponto> pontosLiddar)
        {

        }

        public static List<Ponto> BuscarParadeAng180(int[,] pontoAleatorio, List<Ponto> pontosLiddar)
        {

        }

        public static List<Ponto> BuscarParadeAng270(int[,] pontoAleatorio, List<Ponto> pontosLiddar)
        {

        }

        public static float GeraDefasagemAngulo(Ponto pontoLiddar, float anguloAtual)
        {

        }
    }
}
