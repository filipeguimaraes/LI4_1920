﻿namespace SportsManagerAdmin
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
            this.comboBoxEspaços = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nrVezes = new System.Windows.Forms.TextBox();
            this.ConsultButton = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.ConsultButton);
            this.groupBox1.Controls.Add(this.nrVezes);
            this.groupBox1.Controls.Add(this.comboBoxEspaços);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.espacosRegistados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estatísticas de Espaços";
            // 
            // comboBoxEspaços
            // 
            this.comboBoxEspaços.FormattingEnabled = true;
            this.comboBoxEspaços.Location = new System.Drawing.Point(23, 98);
            this.comboBoxEspaços.Name = "comboBoxEspaços";
            this.comboBoxEspaços.Size = new System.Drawing.Size(192, 21);
            this.comboBoxEspaços.TabIndex = 3;
            this.comboBoxEspaços.Text = "Selecione um Espaço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consultar nº de alugueres de um Espaço";
            // 
            // nrVezes
            // 
            this.nrVezes.Location = new System.Drawing.Point(255, 100);
            this.nrVezes.Name = "nrVezes";
            this.nrVezes.ReadOnly = true;
            this.nrVezes.Size = new System.Drawing.Size(66, 20);
            this.nrVezes.TabIndex = 4;
            // 
            // ConsultButton
            // 
            this.ConsultButton.Location = new System.Drawing.Point(27, 136);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(64, 19);
            this.ConsultButton.TabIndex = 5;
            this.ConsultButton.Text = "Consultar";
            this.ConsultButton.UseVisualStyleBackColor = true;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
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
    }
}