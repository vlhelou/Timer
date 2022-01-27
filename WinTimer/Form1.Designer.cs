namespace WinTimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gAlarme = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gAlarme)).BeginInit();
            this.SuspendLayout();
            // 
            // gAlarme
            // 
            this.gAlarme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAlarme.Location = new System.Drawing.Point(39, 28);
            this.gAlarme.Name = "gAlarme";
            this.gAlarme.RowTemplate.Height = 25;
            this.gAlarme.Size = new System.Drawing.Size(699, 150);
            this.gAlarme.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gAlarme);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gAlarme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView gAlarme;
    }
}