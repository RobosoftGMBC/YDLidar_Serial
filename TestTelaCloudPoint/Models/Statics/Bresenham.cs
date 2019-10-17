using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace TestTelaCloudPoint.Models.Statics
{
    static class Bresenham
    {
        public static int[,] Run(int x1, int y1, int x2, int y2)
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();

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

                    //Adiciona os valores na lista temporaria
                    x.Add(rowCursor/15);
                    y.Add(colCursor/15);
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
                    //Adiciona os valores na lista temporaria
                    x.Add(rowCursor/10);
                    y.Add(colCursor/10);
                }
            }

            int[,] matriz = new int[x.Count, y.Count];
            for (int i = 0; i < x.Count - 1; i++)
            {
                matriz[i, 0] = x[i];
                matriz[i, 1] = y[i];
            }

            return matriz;

        }

        static int sign(int v)
        {
            return v > 0 ? 1 : ((v < 0) ? -1 : 0);
        }

        static int abs(int x)
        {
            return x > 0 ? x : -x;
        }

        static int max(int a, int b)
        {
            return a > b ? a : b;
        }

    }
}
