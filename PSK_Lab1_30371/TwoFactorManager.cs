using System;
using System.Collections.Concurrent;

namespace PSK_Lab1_30371
{
    public static class TwoFactorManager
    {
        private record Entry(string Code, DateTime ExpiresAt, List<DateTime> SentTimestamps, int FailedAttempts);
        private static ConcurrentDictionary<string, Entry> _store = new();
        public static readonly TimeSpan CodeValidFor = TimeSpan.FromMinutes(5);
        public static readonly TimeSpan ResendWindow = TimeSpan.FromMinutes(15);
        public const int MaxResendsInWindow = 3;
        public const int MaxFailedAttempts = 5;

        private static string Normalize(string email) => email?.Trim().ToLowerInvariant() ?? "";

        public static string GenerateAndStoreCode(string email)
        {
            var key = Normalize(email);
            var rnd = new Random();
            var code = rnd.Next(0, 1000000).ToString("D6"); 
            var expires = DateTime.UtcNow.Add(CodeValidFor);

            var now = DateTime.UtcNow;
            _store.AddOrUpdate(key,
                addValueFactory: k => new Entry(code, expires, new List<DateTime> { now }, 0),
                updateValueFactory: (k, old) =>
                {
                    var stamps = old.SentTimestamps ?? new List<DateTime>();
                    stamps.Add(now);
                    return new Entry(code, expires, stamps, 0); 
                });

            return code;
        }

        public static bool CanResend(string email, out int sentInWindow)
        {
            sentInWindow = 0;
            var key = Normalize(email);
            if (!_store.TryGetValue(key, out var e))
            {
                sentInWindow = 0;
                return true;
            }
            var windowStart = DateTime.UtcNow - ResendWindow;
            sentInWindow = e.SentTimestamps.Count(ts => ts >= windowStart);
            return sentInWindow < MaxResendsInWindow;
        }

        public static void InvalidateCode(string email)
        {
            var key = Normalize(email);
            _store.TryRemove(key, out _);
        }

        public static (bool Success, string Message) VerifyCode(string email, string code)
        {
            var key = Normalize(email);
            if (!_store.TryGetValue(key, out var e))
                return (false, "Brak aktywnego kodu. Poproś o wysłanie kodu.");

            if (DateTime.UtcNow > e.ExpiresAt)
            {
                _store.TryRemove(key, out _);
                return (false, "Kod wygasł. Poproś o nowy kod.");
            }

            if (e.FailedAttempts >= MaxFailedAttempts)
            {
                _store.TryRemove(key, out _);
                return (false, "Przekroczono dozwoloną liczbę prób. Wygeneruj nowy kod.");
            }

            if (e.Code == code)
            {
                _store.TryRemove(key, out _);
                return (true, "Kod poprawny.");
            }
            else
            {
                _store.AddOrUpdate(key,
                    addValueFactory: k => new Entry("", DateTime.MinValue, new List<DateTime>(), 1),
                    updateValueFactory: (k, old) =>
                    {
                        var newAttempts = old.FailedAttempts + 1;
                        return new Entry(old.Code, old.ExpiresAt, old.SentTimestamps, newAttempts);
                    });

                int remaining = Math.Max(0, MaxFailedAttempts - (_store.TryGetValue(key, out var updated) ? updated.FailedAttempts : 1));
                return (false, $"Nieprawidłowy kod. Pozostało prób: {remaining}");
            }
        }

        public static (bool Ok, string Message, string Code) ResendCode(string email)
        {
            var key = Normalize(email);
            if (!CanResend(email, out int sent))
            {
                return (false, $"Przekroczono limit wysyłek ({MaxResendsInWindow}) w ciągu {ResendWindow.TotalMinutes} min.", null);
            }

            var code = GenerateAndStoreCode(email);
            return (true, "Wysłano nowy kod.", code);
        }

        public static string PeekCodeForDebug(string email)
        {
            var key = Normalize(email);
            if (!_store.TryGetValue(key, out var e)) return null;
            return e.Code;
        }
    }
}
