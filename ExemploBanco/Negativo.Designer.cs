
namespace ExemploBanco
{
    partial class Negativo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNegado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "                         Acesso negado! \r\nTente inserir suas credenciais novament" +
    "e!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExemploBanco.Properties.Resources.artworks_rRbG6b49294TaJj1_5jegxw_t500x500;
            this.pictureBox1.Location = new System.Drawing.Point(-61, -33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 374);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnNegado
            // 
            this.btnNegado.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegado.Location = new System.Drawing.Point(117, 420);
            this.btnNegado.Name = "btnNegado";
            this.btnNegado.Size = new System.Drawing.Size(139, 51);
            this.btnNegado.TabIndex = 4;
            this.btnNegado.Text = "Prosseguir";
            this.btnNegado.UseVisualStyleBackColor = true;
            this.btnNegado.Click += new System.EventHandler(this.btnNegado_Click);
            // 
            // Negativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 499);
            this.Controls.Add(this.btnNegado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Negativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Negativo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNegado;
    }
}