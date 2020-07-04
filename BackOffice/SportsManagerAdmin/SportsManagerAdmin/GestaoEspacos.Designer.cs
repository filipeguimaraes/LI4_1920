namespace SportsManagerAdmin
{
    partial class GestaoEspacos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.espacosRegistados = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonClasses = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.nrVezes = new System.Windows.Forms.TextBox();
            this.comboBoxEspaços = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lucroEspaco = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Espaços Registados";
            // 
            // espacosRegistados
            // 
            this.espacosRegistados.Location = new System.Drawing.Point(215, 20);
            this.espacosRegistados.Name = "espacosRegistados";
            this.espacosRegistados.ReadOnly = true;
            this.espacosRegistados.Size = new System.Drawing.Size(107, 20);
            this.espacosRegistados.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lucroEspaco);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.ButtonClasses);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ConsultButton);
            this.groupBox1.Controls.Add(this.nrVezes);
            this.groupBox1.Controls.Add(this.comboBoxEspaços);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.espacosRegistados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 405);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estatísticas de Espaços";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(255, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(65, 20);
            this.textBox1.TabIndex = 9;
            // 
            // ButtonClasses
            // 
            this.ButtonClasses.Location = new System.Drawing.Point(19, 240);
            this.ButtonClasses.Name = "ButtonClasses";
            this.ButtonClasses.Size = new System.Drawing.Size(63, 23);
            this.ButtonClasses.TabIndex = 8;
            this.ButtonClasses.Text = "Consultar";
            this.ButtonClasses.UseVisualStyleBackColor = true;
            this.ButtonClasses.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 197);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "Selecione um Espaço";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consultar nº de Aulas/Espaço (média)";
            // 
            // ConsultButton
            // 
            this.ConsultButton.Location = new System.Drawing.Point(19, 136);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(64, 19);
            this.ConsultButton.TabIndex = 5;
            this.ConsultButton.Text = "Consultar";
            this.ConsultButton.UseVisualStyleBackColor = true;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // nrVezes
            // 
            this.nrVezes.Location = new System.Drawing.Point(255, 99);
            this.nrVezes.Name = "nrVezes";
            this.nrVezes.ReadOnly = true;
            this.nrVezes.Size = new System.Drawing.Size(65, 20);
            this.nrVezes.TabIndex = 4;
            // 
            // comboBoxEspaços
            // 
            this.comboBoxEspaços.FormattingEnabled = true;
            this.comboBoxEspaços.Location = new System.Drawing.Point(19, 99);
            this.comboBoxEspaços.Name = "comboBoxEspaços";
            this.comboBoxEspaços.Size = new System.Drawing.Size(192, 21);
            this.comboBoxEspaços.TabIndex = 3;
            this.comboBoxEspaços.Text = "Selecione um Espaço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consultar nº de alugueres de um Espaço";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Consultar lucro médio/Espaço";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(255, 289);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(65, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Consultar lucro de um Espaço";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(19, 347);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 21);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.Text = "Selecione um Espaço";
            // 
            // lucroEspaco
            // 
            this.lucroEspaco.Location = new System.Drawing.Point(19, 380);
            this.lucroEspaco.Name = "lucroEspaco";
            this.lucroEspaco.Size = new System.Drawing.Size(64, 24);
            this.lucroEspaco.TabIndex = 14;
            this.lucroEspaco.Text = "Consultar";
            this.lucroEspaco.UseVisualStyleBackColor = true;
            // 
            // GestaoEspacos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "GestaoEspacos";
            this.Text = "GestaoEspacos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox espacosRegistados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEspaços;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConsultButton;
        private System.Windows.Forms.TextBox nrVezes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonClasses;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button lucroEspaco;
    }
}