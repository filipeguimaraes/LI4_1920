namespace SportsManagerAdmin
{
    partial class GestaoUsers
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
            this.labelUsers = new System.Windows.Forms.Label();
            this.usersRegistados = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Location = new System.Drawing.Point(66, 113);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(165, 13);
            this.labelUsers.TabIndex = 0;
            this.labelUsers.Text = "Número de utilizadores registados";
            // 
            // usersRegistados
            // 
            this.usersRegistados.Location = new System.Drawing.Point(275, 110);
            this.usersRegistados.Name = "usersRegistados";
            this.usersRegistados.ReadOnly = true;
            this.usersRegistados.Size = new System.Drawing.Size(139, 20);
            this.usersRegistados.TabIndex = 1;
            // 
            // GestaoUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usersRegistados);
            this.Controls.Add(this.labelUsers);
            this.Name = "GestaoUsers";
            this.Text = "GestaoUsers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.TextBox usersRegistados;
    }
}