namespace TestDLLSerialLidar
{
    partial class Form1
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
            this.btnListar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtPortaCom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnviaStopScan = new System.Windows.Forms.Button();
            this.btnEnviaStartScan = new System.Windows.Forms.Button();
            this.btnEnviaSoftReboot = new System.Windows.Forms.Button();
            this.btnEnviaHealth = new System.Windows.Forms.Button();
            this.btnEnviaInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtResultado = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtComunicacao = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerAtualiza = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHealthStatus = new System.Windows.Forms.Label();
            this.lblHardwareVersion = new System.Windows.Forms.Label();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(24, 23);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar Portas";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.BtnListar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(142, 23);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(87, 23);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            // 
            // txtPortaCom
            // 
            this.txtPortaCom.Location = new System.Drawing.Point(264, 26);
            this.txtPortaCom.Name = "txtPortaCom";
            this.txtPortaCom.Size = new System.Drawing.Size(100, 20);
            this.txtPortaCom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Porta (Ex: COM3)";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(142, 52);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(87, 23);
            this.btnDesconectar.TabIndex = 5;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.BtnDesconectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnviaStopScan);
            this.groupBox1.Controls.Add(this.btnEnviaStartScan);
            this.groupBox1.Controls.Add(this.btnEnviaSoftReboot);
            this.groupBox1.Controls.Add(this.btnEnviaHealth);
            this.groupBox1.Controls.Add(this.btnEnviaInfo);
            this.groupBox1.Location = new System.Drawing.Point(405, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 128);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enviar";
            // 
            // btnEnviaStopScan
            // 
            this.btnEnviaStopScan.Location = new System.Drawing.Point(99, 55);
            this.btnEnviaStopScan.Name = "btnEnviaStopScan";
            this.btnEnviaStopScan.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaStopScan.TabIndex = 15;
            this.btnEnviaStopScan.Text = "Stop Scann";
            this.btnEnviaStopScan.UseVisualStyleBackColor = true;
            this.btnEnviaStopScan.Click += new System.EventHandler(this.BtnEnviaStopScan_Click);
            // 
            // btnEnviaStartScan
            // 
            this.btnEnviaStartScan.Location = new System.Drawing.Point(99, 26);
            this.btnEnviaStartScan.Name = "btnEnviaStartScan";
            this.btnEnviaStartScan.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaStartScan.TabIndex = 14;
            this.btnEnviaStartScan.Text = "Start Scann";
            this.btnEnviaStartScan.UseVisualStyleBackColor = true;
            this.btnEnviaStartScan.Click += new System.EventHandler(this.BtnEnviaStartScan_Click);
            // 
            // btnEnviaSoftReboot
            // 
            this.btnEnviaSoftReboot.Location = new System.Drawing.Point(18, 84);
            this.btnEnviaSoftReboot.Name = "btnEnviaSoftReboot";
            this.btnEnviaSoftReboot.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaSoftReboot.TabIndex = 13;
            this.btnEnviaSoftReboot.Text = "Solft reboot";
            this.btnEnviaSoftReboot.UseVisualStyleBackColor = true;
            this.btnEnviaSoftReboot.Click += new System.EventHandler(this.BtnEnviaSoftReboot_Click);
            // 
            // btnEnviaHealth
            // 
            this.btnEnviaHealth.Location = new System.Drawing.Point(18, 55);
            this.btnEnviaHealth.Name = "btnEnviaHealth";
            this.btnEnviaHealth.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaHealth.TabIndex = 12;
            this.btnEnviaHealth.Text = "Health";
            this.btnEnviaHealth.UseVisualStyleBackColor = true;
            this.btnEnviaHealth.Click += new System.EventHandler(this.BtnEnviaHealth_Click);
            // 
            // btnEnviaInfo
            // 
            this.btnEnviaInfo.Location = new System.Drawing.Point(18, 26);
            this.btnEnviaInfo.Name = "btnEnviaInfo";
            this.btnEnviaInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEnviaInfo.TabIndex = 11;
            this.btnEnviaInfo.Text = "Info";
            this.btnEnviaInfo.UseVisualStyleBackColor = true;
            this.btnEnviaInfo.Click += new System.EventHandler(this.BtnEnviaInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtResultado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 100);
            this.panel1.TabIndex = 12;
            // 
            // rtResultado
            // 
            this.rtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtResultado.Location = new System.Drawing.Point(0, 19);
            this.rtResultado.Name = "rtResultado";
            this.rtResultado.Size = new System.Drawing.Size(858, 79);
            this.rtResultado.TabIndex = 14;
            this.rtResultado.Text = "";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(858, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rtComunicacao);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 141);
            this.panel2.TabIndex = 13;
            // 
            // rtComunicacao
            // 
            this.rtComunicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtComunicacao.Location = new System.Drawing.Point(0, 19);
            this.rtComunicacao.Name = "rtComunicacao";
            this.rtComunicacao.Size = new System.Drawing.Size(858, 120);
            this.rtComunicacao.TabIndex = 14;
            this.rtComunicacao.Text = "";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(858, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comunicacao";
            // 
            // timerAtualiza
            // 
            this.timerAtualiza.Interval = 10;
            this.timerAtualiza.Tick += new System.EventHandler(this.TimerAtualiza_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHealthStatus);
            this.groupBox2.Controls.Add(this.lblHardwareVersion);
            this.groupBox2.Controls.Add(this.lblFirmware);
            this.groupBox2.Controls.Add(this.lblModelo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(612, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 128);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info. Disp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Health Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Hardware Version:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Firmware:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Modelo:";
            // 
            // lblHealthStatus
            // 
            this.lblHealthStatus.Location = new System.Drawing.Point(115, 93);
            this.lblHealthStatus.Name = "lblHealthStatus";
            this.lblHealthStatus.Size = new System.Drawing.Size(108, 13);
            this.lblHealthStatus.TabIndex = 25;
            this.lblHealthStatus.Text = "...";
            // 
            // lblHardwareVersion
            // 
            this.lblHardwareVersion.Location = new System.Drawing.Point(115, 69);
            this.lblHardwareVersion.Name = "lblHardwareVersion";
            this.lblHardwareVersion.Size = new System.Drawing.Size(108, 13);
            this.lblHardwareVersion.TabIndex = 24;
            this.lblHardwareVersion.Text = "...";
            // 
            // lblFirmware
            // 
            this.lblFirmware.Location = new System.Drawing.Point(115, 44);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(108, 13);
            this.lblFirmware.TabIndex = 23;
            this.lblFirmware.Text = "...";
            // 
            // lblModelo
            // 
            this.lblModelo.Location = new System.Drawing.Point(115, 21);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(108, 13);
            this.lblModelo.TabIndex = 22;
            this.lblModelo.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPortaCom);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnListar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtPortaCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnviaStopScan;
        private System.Windows.Forms.Button btnEnviaStartScan;
        private System.Windows.Forms.Button btnEnviaSoftReboot;
        private System.Windows.Forms.Button btnEnviaHealth;
        private System.Windows.Forms.Button btnEnviaInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtResultado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtComunicacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerAtualiza;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHealthStatus;
        private System.Windows.Forms.Label lblHardwareVersion;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

