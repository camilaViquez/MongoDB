namespace investigacion
{
    partial class Ayuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.PDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDF)).BeginInit();
            this.SuspendLayout();
            // 
            // PDF
            // 
            this.PDF.Enabled = true;
            this.PDF.Location = new System.Drawing.Point(12, 23);
            this.PDF.Name = "PDF";
            this.PDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDF.OcxState")));
            this.PDF.Size = new System.Drawing.Size(420, 470);
            this.PDF.TabIndex = 0;
            this.PDF.Enter += new System.EventHandler(this.axAcroPDF1_Enter);
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 644);
            this.Controls.Add(this.PDF);
            this.Name = "Ayuda";
            this.Text = "Ayuda";
            ((System.ComponentModel.ISupportInitialize)(this.PDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDF;
    }
}