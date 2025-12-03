namespace PSK_Lab1_30371
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            comboBase = new ComboBox();
            comboTarget = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            btnGetRate = new Button();
            lblRate = new Label();
            colorDialog1 = new ColorDialog();
            btnRefreshSymbols = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // comboBase
            // 
            comboBase.FormattingEnabled = true;
            comboBase.Location = new Point(140, 97);
            comboBase.Name = "comboBase";
            comboBase.Size = new Size(121, 23);
            comboBase.TabIndex = 0;
            // 
            // comboTarget
            // 
            comboTarget.FormattingEnabled = true;
            comboTarget.Location = new Point(316, 97);
            comboTarget.Name = "comboTarget";
            comboTarget.Size = new Size(121, 23);
            comboTarget.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnGetRate
            // 
            btnGetRate.Location = new Point(140, 172);
            btnGetRate.Name = "btnGetRate";
            btnGetRate.Size = new Size(75, 23);
            btnGetRate.TabIndex = 2;
            btnGetRate.Text = "Zamień";
            btnGetRate.UseVisualStyleBackColor = true;
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Location = new Point(513, 105);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(0, 15);
            lblRate.TabIndex = 3;
            // 
            // btnRefreshSymbols
            // 
            btnRefreshSymbols.Location = new Point(362, 172);
            btnRefreshSymbols.Name = "btnRefreshSymbols";
            btnRefreshSymbols.Size = new Size(75, 23);
            btnRefreshSymbols.TabIndex = 4;
            btnRefreshSymbols.Text = "Odśwież";
            btnRefreshSymbols.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 65);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 5;
            label1.Text = "Waluta początkowa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 65);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 6;
            label2.Text = "Waluta docelowa";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 254);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefreshSymbols);
            Controls.Add(lblRate);
            Controls.Add(btnGetRate);
            Controls.Add(comboTarget);
            Controls.Add(comboBase);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBase;
        private ComboBox comboTarget;
        private ErrorProvider errorProvider1;
        private Button btnRefreshSymbols;
        private Label lblRate;
        private Button btnGetRate;
        private ColorDialog colorDialog1;
        private Label label2;
        private Label label1;
    }
}