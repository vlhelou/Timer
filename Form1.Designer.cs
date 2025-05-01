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
            btnAcao = new Button();
            lbFalta = new Label();
            chMudo = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnAcao
            // 
            btnAcao.Location = new Point(8, 3);
            btnAcao.Name = "btnAcao";
            btnAcao.Size = new Size(58, 28);
            btnAcao.TabIndex = 2;
            btnAcao.Text = "Inicia";
            btnAcao.UseVisualStyleBackColor = true;
            btnAcao.Click += btnAcao_Click;
            // 
            // lbFalta
            // 
            lbFalta.AutoSize = true;
            lbFalta.Font = new Font("Segoe UI", 35F);
            lbFalta.Location = new Point(136, 2);
            lbFalta.Name = "lbFalta";
            lbFalta.Size = new Size(84, 62);
            lbFalta.TabIndex = 3;
            lbFalta.Text = "---";
            lbFalta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chMudo
            // 
            chMudo.AutoSize = true;
            chMudo.Location = new Point(72, 9);
            chMudo.Name = "chMudo";
            chMudo.Size = new Size(58, 19);
            chMudo.TabIndex = 4;
            chMudo.Text = "Mudo";
            chMudo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(8, 34);
            button1.Name = "button1";
            button1.Size = new Size(58, 28);
            button1.TabIndex = 5;
            button1.Text = "Auto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAutomatico_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 69);
            Controls.Add(button1);
            Controls.Add(chMudo);
            Controls.Add(lbFalta);
            Controls.Add(btnAcao);
            Name = "Form1";
            Text = "Timer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Button btnAcao;
        private Label lbFalta;
        private CheckBox chMudo;
        private Button button1;
    }
}