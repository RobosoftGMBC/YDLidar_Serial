using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TestTelaCloudPoint
{
    class MapaFisico
    {
        public int[,] matriz;
        string[] file;
        int indexMatriz = 0;
        public int[,] CarregarMapa()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file = File.ReadAllLines(dialog.FileName);
            }
            else
                return null;

            matriz = new int[4500, 4000];
            
            for (int i = 0; i < file.Length; i++)
            {
                string linha = file[i];
                indexMatriz = 0;
                for (int j = 0; j < linha.Length; j++)
                {
                    if (linha[j] != ';')
                    {
                        matriz[i, indexMatriz++] = 1;
                        j++;
                    }
                    else
                        matriz[i, indexMatriz++] = 0;
                }
            }

            return matriz;
        }

    }
}
