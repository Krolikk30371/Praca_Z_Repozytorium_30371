
namespace PSK_Lab1_30371
{
    public partial class LoginForm : Form
    {
        private EmailService _emailService;

        public LoginForm()
        {
            InitializeComponent();

            _emailService = new EmailService(
             smtpHost: "smtp.wp.pl",
             smtpPort: 587,
             smtpUser: "noreply30371@wp.pl",
             smtpPass: "Noreplypass1!",
             fromAddress: "noreply30371@wp.pl"
             );
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (!UserManager.ValidateUser(email, password))
            {
                lblStatus.Text = "B³êdny email lub has³o.";
                return;
            }


            if (!TwoFactorManager.CanResend(email, out int sent))
            {
                lblStatus.Text = $"Przekroczono limit wysy³ek ({sent} wys³anych). Spróbuj póŸniej.";
                return;
            }

            var code = TwoFactorManager.GenerateAndStoreCode(email);

            try
            {
                await _emailService.SendTwoFactorCodeAsync(email, code);
                lblStatus.Text = "Kod wys³any na e-mail.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "B³¹d wysy³ki: " + ex.Message;
                return;
            }
            this.Hide();
            using var vf = new VerifyForm(email, _emailService);
            var dr = vf.ShowDialog();
            if (vf.Verified)
            {
                using var main = new MainForm(email);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            this.Show();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var reg = new RegisterForm())
            {
                var dr = reg.ShowDialog(); 
            }

            this.Show();
        }
    }
}
