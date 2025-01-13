namespace PDFAddLinksDynamically
{
    partial class Form1
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
            this.defaultUrlText = new System.Windows.Forms.TextBox();
            this.sysConsole = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultUrlText
            // 
            this.defaultUrlText.Enabled = false;
            this.defaultUrlText.Location = new System.Drawing.Point(28, 58);
            this.defaultUrlText.Name = "defaultUrlText";
            this.defaultUrlText.Size = new System.Drawing.Size(542, 22);
            this.defaultUrlText.TabIndex = 0;
            // 
            // sysConsole
            // 
            this.sysConsole.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sysConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sysConsole.ForeColor = System.Drawing.SystemColors.InfoText;
            this.sysConsole.Location = new System.Drawing.Point(28, 182);
            this.sysConsole.Name = "sysConsole";
            this.sysConsole.ReadOnly = true;
            this.sysConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sysConsole.Size = new System.Drawing.Size(736, 256);
            this.sysConsole.TabIndex = 1;
            this.sysConsole.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default base URL:";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(613, 24);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(151, 54);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sysConsole);
            this.Controls.Add(this.defaultUrlText);
            this.Name = "Form1";
            this.Text = "PDF Linker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defaultUrlText;
        public System.Windows.Forms.RichTextBox sysConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBtn;
    }
}

