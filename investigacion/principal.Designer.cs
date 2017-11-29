namespace investigacion
{
    partial class principal
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnIngreasr = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIngreasr
            // 
            this.btnIngreasr.Location = new System.Drawing.Point(149, 182);
            this.btnIngreasr.Name = "btnIngreasr";
            this.btnIngreasr.Size = new System.Drawing.Size(136, 32);
            this.btnIngreasr.TabIndex = 1;
            this.btnIngreasr.Text = "Ingresar";
            this.btnIngreasr.UseVisualStyleBackColor = true;
            this.btnIngreasr.Click += new System.EventHandler(this.btnIngreasr_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ayuda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "Borrar Usuario";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 411);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIngreasr);
            this.Controls.Add(this.button1);
            this.Name = "principal";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIngreasr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}