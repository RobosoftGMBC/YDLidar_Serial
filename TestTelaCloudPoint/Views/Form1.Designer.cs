namespace TestTelaCloudPoint
{
    partial class FrmRBSLiddar
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMatrizAleatoria = new System.Windows.Forms.Button();
            this.btnCarregarMapa = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.timerPontosNaTela = new System.Windows.Forms.Timer(this.components);
            this.timerAtualizaLiddar = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbMapaLeitura = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pbLiddar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbPontosAleatorios = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaLeitura)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLiddar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPontosAleatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMatrizAleatoria);
            this.panel2.Controls.Add(this.btnCarregarMapa);
            this.panel2.Controls.Add(this.btnDesconectar);
            this.panel2.Controls.Add(this.txtPorta);
            this.panel2.Controls.Add(this.btnConectar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1503, 58);
            this.panel2.TabIndex = 4;
            // 
            // btnMatrizAleatoria
            // 
            this.btnMatrizAleatoria.Location = new System.Drawing.Point(255, 29);
            this.btnMatrizAleatoria.Name = "btnMatrizAleatoria";
            this.btnMatrizAleatoria.Size = new System.Drawing.Size(172, 23);
            this.btnMatrizAleatoria.TabIndex = 9;
            this.btnMatrizAleatoria.Text = "Gerar Matriz Aleatoria";
            this.btnMatrizAleatoria.UseVisualStyleBackColor = true;
            this.btnMatrizAleatoria.Click += new System.EventHandler(this.btnMatrizAleatoria_Click);
            // 
            // btnCarregarMapa
            // 
            this.btnCarregarMapa.Location = new System.Drawing.Point(255, 0);
            this.btnCarregarMapa.Name = "btnCarregarMapa";
            this.btnCarregarMapa.Size = new System.Drawing.Size(172, 23);
            this.btnCarregarMapa.TabIndex = 8;
            this.btnCarregarMapa.Text = "Carregar Novo Mapa";
            this.btnCarregarMapa.UseVisualStyleBackColor = true;
            this.btnCarregarMapa.Click += new System.EventHandler(this.btnCarregarMapa_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(3, 32);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(87, 23);
            this.btnDesconectar.TabIndex = 5;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(97, 3);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(100, 20);
            this.txtPorta.TabIndex = 4;
            this.txtPorta.Text = "COM3";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(3, 3);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(87, 23);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // timerAtualizaLiddar
            // 
            this.timerAtualizaLiddar.Enabled = true;
            this.timerAtualizaLiddar.Interval = 200;
            this.timerAtualizaLiddar.Tick += new System.EventHandler(this.timerAtualizaLiddar_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitter2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1110, 768);
            this.panel4.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 623);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1110, 3);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbMapaLeitura);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 623);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1110, 145);
            this.panel3.TabIndex = 11;
            // 
            // pbMapaLeitura
            // 
            this.pbMapaLeitura.BackColor = System.Drawing.Color.White;
            this.pbMapaLeitura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMapaLeitura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMapaLeitura.Location = new System.Drawing.Point(0, 0);
            this.pbMapaLeitura.Name = "pbMapaLeitura";
            this.pbMapaLeitura.Size = new System.Drawing.Size(1110, 145);
            this.pbMapaLeitura.TabIndex = 3;
            this.pbMapaLeitura.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pbLiddar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1110, 623);
            this.panel5.TabIndex = 10;
            // 
            // pbLiddar
            // 
            this.pbLiddar.BackColor = System.Drawing.Color.White;
            this.pbLiddar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLiddar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLiddar.Location = new System.Drawing.Point(0, 0);
            this.pbLiddar.Name = "pbLiddar";
            this.pbLiddar.Size = new System.Drawing.Size(1110, 623);
            this.pbLiddar.TabIndex = 1;
            this.pbLiddar.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1110, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 768);
            this.panel1.TabIndex = 9;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 504);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(393, 3);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 504);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(393, 264);
            this.panel7.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pbPontosAleatorios);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(393, 504);
            this.panel6.TabIndex = 1;
            // 
            // pbPontosAleatorios
            // 
            this.pbPontosAleatorios.BackColor = System.Drawing.Color.White;
            this.pbPontosAleatorios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPontosAleatorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPontosAleatorios.Location = new System.Drawing.Point(0, 0);
            this.pbPontosAleatorios.Name = "pbPontosAleatorios";
            this.pbPontosAleatorios.Size = new System.Drawing.Size(393, 504);
            this.pbPontosAleatorios.TabIndex = 1;
            this.pbPontosAleatorios.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(1110, 58);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 768);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // FrmRBSLiddar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 826);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "FrmRBSLiddar";
            this.Text = "Robosoft Liddar";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMapaLeitura)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLiddar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPontosAleatorios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Timer timerPontosNaTela;
        private System.Windows.Forms.Button btnCarregarMapa;
        private System.Windows.Forms.Timer timerAtualizaLiddar;
        private System.Windows.Forms.Button btnMatrizAleatoria;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbMapaLeitura;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pbLiddar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pbPontosAleatorios;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
    }
}

