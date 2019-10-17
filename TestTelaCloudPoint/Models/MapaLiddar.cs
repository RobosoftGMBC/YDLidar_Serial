using RBS_YDLidarSerial;
using System;
using System.Collections.Generic;
using TestTelaCloudPoint.Models.Statics;

namespace TestTelaCloudPoint.Models
{
    class MapaLiddar
    {
       
        public List<Coordenada> BuscarCoordenadasLidar(Ponto[] pontos, int origemX, int origemY)
        {
            
            int alcanceLidar = 10000;

            List<Coordenada> coordenadas = new List<Coordenada>();
            foreach (Ponto ponto in pontos)
            {
                if (ponto != null)
                {
                    if (ponto.Distancia > 0 && !ponto.lido)
                    {
                        ponto.lido = true;
                        float x = (float)(Convert.ToDouble(ponto.Distancia) * Math.Sin(Utils.ConvertToRadians(Convert.ToDouble(ponto.Angulo))));
                        float y = (float)(Convert.ToDouble(ponto.Distancia) * Math.Cos(Utils.ConvertToRadians(Convert.ToDouble(ponto.Angulo))));

                        Coordenada c = new Coordenada((int)Math.Round(x), (int)Math.Round(y), (int)(x - origemX), (int)(y - origemY), ponto.Angulo, ponto.Distancia);
                        coordenadas.Add(c);

                    }
                }
            }
            return coordenadas;
        }
    }
}
