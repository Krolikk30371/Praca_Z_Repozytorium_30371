using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSK_Lab1_30371
{
    public partial class VerifyForm : Form
    {
        private string _email;
        private EmailService _emailService;
        public bool Verified { get; private set; }

        public VerifyForm(string email, EmailService emailService)
        {
            InitializeComponent();
            _email = email;
            _emailService = emailService;
            lblInfo.Text = $"Kod wysłany na: {_email}";
            Verified = false;
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text.Trim();
            var (ok, msg) = TwoFactorManager.VerifyCode(_email, code);
            if (ok)
            {
                Verified = true;
                MessageBox.Show("Weryfikacja OK.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
        private async void btnResend_Click(object sender, EventArgs e)
        {
            var (ok, message, code) = TwoFactorManager.ResendCode(_email);
            if (!ok)
            {
                MessageBox.Show(message);
                return;
            }

            try
            {
                await _emailService.SendTwoFactorCodeAsync(_email, code);
                MessageBox.Show("Wysłano ponownie kod na e-mail.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wysyłki: " + ex.Message);
            }
        }
    }


}
