﻿namespace WinTimer
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.btnAcao.Location = new System.Drawing.Point(128, 3);
            this.btnAcao.Name = "btnAcao";
            this.btnAcao.Size = new System.Drawing.Size(58, 28);
            this.btnAcao.TabIndex = 2;
            this.btnAcao.Text = "Inicia";
            this.btnAcao.UseVisualStyleBackColor = true;
            this.btnAcao.Click += new System.EventHandler(this.btnAcao_Click);
            // 
            // lbFalta
            // 
            this.lbFalta.AutoSize = true;
            this.lbFalta.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFalta.Location = new System.Drawing.Point(256, 2);
            this.lbFalta.Name = "lbFalta";
            this.lbFalta.Size = new System.Drawing.Size(84, 62);
            this.lbFalta.TabIndex = 3;
            this.lbFalta.Text = "---";
            this.lbFalta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chMudo
            // 
            this.chMudo.AutoSize = true;
            this.chMudo.Location = new System.Drawing.Point(192, 9);
            this.chMudo.Name = "chMudo";
            this.chMudo.Size = new System.Drawing.Size(58, 19);
            this.chMudo.TabIndex = 4;
            this.chMudo.Text = "Mudo";
            this.chMudo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Auto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAutomatico_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 70);
            this.Controls.Add(this.button1);
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
        private Button button1;
    }
}