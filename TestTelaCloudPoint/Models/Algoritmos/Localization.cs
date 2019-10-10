using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTelaCloudPoint.Controllers
{
    class Localization
    {
        public List<int[,]> GerarPontosRandomicos(int valorMaxX, int valorMaxY, int qntPonto)
        {
            List<int[,]> pontos = new List<int[,]>();
            int x = 0, y = 0, a = 0;
            Random randon = new Random();

            for (int i = 1; i < qntPonto; i++)
            {
                x = randon.Next(0, valorMaxX);
                y = randon.Next(0, valorMaxY);
                a = randon.Next(360);
                int[,] p = new int[1, 3];
                p[0, 0] = x;
                p[0, 1] = y;
                p[0, 2] = a;

                pontos.Add(p);
            }

            return pontos;
        }
    }
}
