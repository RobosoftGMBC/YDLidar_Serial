using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TestTelaCloudPoint.Controllers;
using TestTelaCloudPoint.Models.Statics;

namespace TestTelaCloudPoint
{

    public partial class FrmRBSLiddar : Form
    {
        Controller controller = new Controller();

        public FrmRBSLiddar()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            controller.ConectarLiddar(txtPorta.Text);
            timerPontosNaTela.Start();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            controller.DesconectarLiddar();
            timerPontosNaTela.Stop();
        }

        private void btnCarregarMapa_Click(object sender, EventArgs e)
        {
            pbMapaLeitura.Image = controller.BuscarMapaFisico(pbLiddar.Width, pbLiddar.Height);
        }

        private void btnMatrizAleatoria_Click(object sender, EventArgs e)
        {
           pbPontosAleatorios.Image = controller.BuscarMapaAleatorio(pbPontosAleatorios.Width, pbPontosAleatorios.Height);
        }

        private void timerAtualizaLiddar_Tick(object sender, EventArgs e)
        {
            if (controller.LiddarConectado())
                pbLiddar.Image = controller.BuscarMapaLiddar(pbLiddar.Width, pbLiddar.Height);
        }
    }
}
