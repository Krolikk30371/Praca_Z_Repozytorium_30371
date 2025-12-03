using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSK_Lab1_30371
{
    public partial class MainForm : Form
    {
        private readonly string _email;
        private readonly CurrencyService _currencyService;

        public MainForm(string email)
        {
            _email = email;
            InitializeComponent();

            _currencyService = new CurrencyService();

            this.Load += MainForm_Load;
            btnGetRate.Click += BtnGetRate_Click;
            btnRefreshSymbols.Click += BtnRefreshSymbols_Click;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            lblRate.Text = "Ładowanie listy walut...";
            await LoadSymbolsAsync();
        }

        private async Task LoadSymbolsAsync()
        {
            try
            {
                var symbols = await _currencyService.GetSymbolsAsync();

                if (symbols.Count == 0)
                {
                    lblRate.Text = "Brak symboli!";
                    return;
                }

                var list = symbols
                    .OrderBy(k => k.Key)
                    .Select(k => k.Key)
                    .ToList();

                comboBase.Items.Clear();
                comboTarget.Items.Clear();

                comboBase.Items.AddRange(list.Cast<object>().ToArray());
                comboTarget.Items.AddRange(list.Cast<object>().ToArray());

                if (list.Contains("USD"))
                    comboBase.SelectedItem = "USD";

                if (list.Contains("PLN"))
                    comboTarget.SelectedItem = "PLN";

                lblRate.Text = "Waluty załadowane.";
            }
            catch (Exception ex)
            {
                lblRate.Text = "Błąd pobierania listy walut.";
                MessageBox.Show(ex.Message, "Błąd");
            }
        }

        private async void BtnRefreshSymbols_Click(object sender, EventArgs e)
        {
            lblRate.Text = "Odświeżanie...";
            await LoadSymbolsAsync();
        }

        private async void BtnGetRate_Click(object sender, EventArgs e)
        {
            var from = comboBase.SelectedItem?.ToString();
            var to = comboTarget.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                lblRate.Text = "Wybierz waluty!";
                return;
            }

            if (from == to)
            {
                lblRate.Text = "Te same waluty → kurs = 1";
                return;
            }

            lblRate.Text = "Pobieranie kursu...";

            try
            {
                var rate = await _currencyService.GetRateAsync(from, to);

                if (rate == null)
                {
                    lblRate.Text = "Nie udało się pobrać kursu.";
                    return;
                }

                lblRate.Text = $"1 {from} = {rate:F4} {to}";
            }
            catch (Exception ex)
            {
                lblRate.Text = "Błąd przy pobieraniu kursu!";
                MessageBox.Show(ex.Message, "Błąd");
            }
        }
    }
}
