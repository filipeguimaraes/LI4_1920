namespace SportsManagerAdmin
{
    partial class Form2
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
            this.gestaoUsers = new System.Windows.Forms.Button();
            this.gestaoEspacos = new System.Windows.Forms.Button();
            this.gestaoAulas = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gestaoUsers
            // 
            this.gestaoUsers.Location = new System.Drawing.Point(102, 57);
            this.gestaoUsers.Name = "gestaoUsers";
            this.gestaoUsers.Size = new System.Drawing.Size(91, 42);
            this.gestaoUsers.TabIndex = 0;
            this.gestaoUsers.Text = "Gerir Utilizadores";
            this.gestaoUsers.UseVisualStyleBackColor = true;
            this.gestaoUsers.Click += new System.EventHandler(this.gestaoUsers_Click);
            // 
            // gestaoEspacos
            // 
            this.gestaoEspacos.Location = new System.Drawing.Point(564, 57);
            this.gestaoEspacos.Name = "gestaoEspacos";
            this.gestaoEspacos.Size = new System.Drawing.Size(91, 42);
            this.gestaoEspacos.TabIndex = 1;
            this.gestaoEspacos.Text = "Gerir Espaços";
            this.gestaoEspacos.UseVisualStyleBackColor = true;
            this.gestaoEspacos.Click += new System.EventHandler(this.gestaoEspacos_Click);
            // 
            // gestaoAulas
            // 
            this.gestaoAulas.Location = new System.Drawing.Point(102, 217);
            this.gestaoAulas.Name = "gestaoAulas";
            this.gestaoAulas.Size = new System.Drawing.Size(91, 42);
            this.gestaoAulas.TabIndex = 2;
            this.gestaoAulas.Text = "Gerir Aulas";
            this.gestaoAulas.UseVisualStyleBackColor = true;
            this.gestaoAulas.Click += new System.EventHandler(this.gestaoAulas_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(564, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.gestaoAulas);
            this.Controls.Add(this.gestaoEspacos);
            this.Controls.Add(this.gestaoUsers);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gestaoUsers;
        private System.Windows.Forms.Button gestaoEspacos;
        private System.Windows.Forms.Button gestaoAulas;
        private System.Windows.Forms.Button button4;
    }
}