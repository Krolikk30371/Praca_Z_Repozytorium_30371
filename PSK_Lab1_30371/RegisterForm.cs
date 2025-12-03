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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var pass = txtPassword.Text;
            var pass2 = txtConfirm.Text;

            lblStatus.Text = "";

            if (string.IsNullOrWhiteSpace(email))
            {
                lblStatus.Text = "Wpisz email.";
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                lblStatus.Text = "Wpisz hasło.";
                return;
            }

            if (pass != pass2)
            {
                lblStatus.Text = "Hasła nie są takie same.";
                return;
            }

            if (UserManager.UserExists(email))
            {
                lblStatus.Text = "Taki email już istnieje!";
                return;
            }

            UserManager.CreateUser(email, pass);

            MessageBox.Show("Użytkownik zarejestrowany!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
