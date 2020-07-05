namespace SportsManagerAdmin
{
    partial class GestaoAulas
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
            this.label2 = new System.Windows.Forms.Label();
            this.aulas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mediaAlunos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número de aulas criadas";
            // 
            // aulas
            // 
            this.aulas.Location = new System.Drawing.Point(252, 58);
            this.aulas.Name = "aulas";
            this.aulas.ReadOnly = true;
            this.aulas.Size = new System.Drawing.Size(120, 20);
            this.aulas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número médio de alunos por aula";
            // 
            // mediaAlunos
            // 
            this.mediaAlunos.Location = new System.Drawing.Point(252, 103);
            this.mediaAlunos.Name = "mediaAlunos";
            this.mediaAlunos.ReadOnly = true;
            this.mediaAlunos.Size = new System.Drawing.Size(119, 20);
            this.mediaAlunos.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lucro médio por aula";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(252, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 6;
            // 
            // GestaoAulas
            // 
            this.ClientSize = new System.Drawing.Size(748, 383);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mediaAlunos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aulas);
            this.Controls.Add(this.label2);
            this.Name = "GestaoAulas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox aulas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mediaAlunos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}