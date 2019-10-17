using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTelaCloudPoint.Models.Statics
{
    public class Coordenada
    {
        public int x, y;
        public int p, dx, dy; //algoritmo de bresenham
        public float angulo, distancia;
        public Coordenada(int x, int y, int dx, int dy, float angulo, float distancia)
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
