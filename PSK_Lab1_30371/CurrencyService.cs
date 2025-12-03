using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PSK_Lab1_30371
{
    public class CurrencyService : IDisposable
    {
        private readonly HttpClient _http = new HttpClient();
        private const string BaseUrl = "https://api.frankfurter.app";

        public async Task<Dictionary<string, string>> GetSymbolsAsync()
        {
            var json = await _http.GetStringAsync($"{BaseUrl}/currencies");
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                   ?? new Dictionary<string, string>();
        }

        public async Task<decimal?> GetRateAsync(string from, string to)
        {
            var json = await _http.GetStringAsync($"{BaseUrl}/latest?from={from}&to={to}");
            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("rates", out var rates) &&
                rates.TryGetProperty(to, out var val))
            {
                return val.GetDecimal();
            }
            return null;
        }

        public void Dispose() => _http.Dispose();
    }
}