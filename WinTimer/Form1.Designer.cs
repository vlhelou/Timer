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
            this.txtIntervalo = new System.Windows.Forms.TextBox();
            this.btnAcao = new System.Windows.Forms.Button();
            this.lbFalta = new System.Windows.Forms.Label();
            this.chMudo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtIntervalo
            // 
            this.txtIntervalo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIntervalo.Location = new System.Drawing.Point(2, 3);
            this.txtIntervalo.Name = "txtIntervalo";
            this.txtIntervalo.Size = new System.Drawing.Size(120, 61);
            this.txtIntervalo.TabIndex = 1;
            this.txtIntervalo.Text = "300";
            this.txtIntervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAcao
            // 
            this.btnAcao.Location = new System.Drawing.Point(144, 3);
            this.btnAcao.Name = "btnAcao";
            this.btnAcao.Size = new System.Drawing.Size(74, 28);
            this.btnAcao.TabIndex = 2;
            this.btnAcao.Text = "Inicia";
            this.btnAcao.UseVisualStyleBackColor = true;
            this.btnAcao.Click += new System.EventHandler(this.btnAcao_Click);
            // 
            // lbFalta
            // 
            this.lbFalta.AutoSize = true;
            this.lbFalta.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFalta.Location = new System.Drawing.Point(238, 3);
            this.lbFalta.Name = "lbFalta";
            this.lbFalta.Size = new System.Drawing.Size(151, 62);
            this.lbFalta.TabIndex = 3;
            this.lbFalta.Text = "label1";
            // 
            // chMudo
            // 
            this.chMudo.AutoSize = true;
            this.chMudo.Location = new System.Drawing.Point(146, 39);
            this.chMudo.Name = "chMudo";
            this.chMudo.Size = new System.Drawing.Size(58, 19);
            this.chMudo.TabIndex = 4;
            this.chMudo.Text = "Mudo";
            this.chMudo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 100);
            this.Controls.Add(this.chMudo);
            this.Controls.Add(this.lbFalta);
            this.Controls.Add(this.btnAcao);
            this.Controls.Add(this.txtIntervalo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtIntervalo;
        private Button btnAcao;
        private Label lbFalta;
        private CheckBox chMudo;
    }
}