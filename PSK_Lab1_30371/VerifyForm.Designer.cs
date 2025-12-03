namespace PSK_Lab1_30371
{
    partial class VerifyForm
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
            lblInfo = new Label();
            txtCode = new TextBox();
            btnVerify = new Button();
            btnResend = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(57, 23);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 15);
            lblInfo.TabIndex = 0;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(57, 83);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(295, 23);
            txtCode.TabIndex = 1;
            // 
            // btnVerify
            // 
            btnVerify.Location = new Point(57, 112);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(103, 23);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "Zweryfikuj";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnResend
            // 
            btnResend.Location = new Point(219, 112);
            btnResend.Name = "btnResend";
            btnResend.Size = new Size(133, 23);
            btnResend.TabIndex = 3;
            btnResend.Text = "Wyślij ponownie";
            btnResend.UseVisualStyleBackColor = true;
            btnResend.Click += btnResend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 65);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 5;
            label1.Text = "Wpisz 6-cyfrowy kod";
            // 
            // VerifyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 245);
            Controls.Add(label1);
            Controls.Add(btnResend);
            Controls.Add(btnVerify);
            Controls.Add(txtCode);
            Controls.Add(lblInfo);
            Name = "VerifyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VerifyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private TextBox txtCode;
        private Button btnVerify;
        private Button btnResend;
        private Label label1;
    }
}