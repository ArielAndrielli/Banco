
namespace ExemploBanco
{
    partial class Extrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Extrato));
            this.dgv_ExtratoLegal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExtratoLegal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ExtratoLegal
            // 
            this.dgv_ExtratoLegal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExtratoLegal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExtratoLegal.Location = new System.Drawing.Point(0, 0);
            this.dgv_ExtratoLegal.Name = "dgv_ExtratoLegal";
            this.dgv_ExtratoLegal.ReadOnly = true;
            this.dgv_ExtratoLegal.Size = new System.Drawing.Size(744, 211);
            this.dgv_ExtratoLegal.TabIndex = 0;
            // 
            // Extrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 211);
            this.Controls.Add(this.dgv_ExtratoLegal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Extrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrato";
            this.Load += new System.EventHandler(this.Extrato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExtratoLegal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ExtratoLegal;
    }
}