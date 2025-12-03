using System;
using Microsoft.Data.SqlClient;

namespace PSK_Lab1_30371
{
    public static class UserManager
    {
        private static string connString =
           @"Server=MARIO\SQLEXPRESS01;Database=BazaUzytkownikow;Trusted_Connection=True;TrustServerCertificate=True;";



        public static bool UserExists(string email)
        {
            using var con = new SqlConnection(connString);
            con.Open();

            using var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Users WHERE Email = @e", con);
            cmd.Parameters.AddWithValue("@e", email);

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public static void CreateUser(string email, string password)
        {
            using var con = new SqlConnection(connString);
            con.Open();

            using var cmd = new SqlCommand(
                "INSERT INTO Users (Email, Password, CreatedAt) VALUES (@e, @p, GETDATE())", con);

            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", password); 

            cmd.ExecuteNonQuery();
        }

        public static bool ValidateUser(string email, string password)
        {
            using var con = new SqlConnection(connString);
            con.Open();

            using var cmd = new SqlCommand(
                "SELECT Password FROM Users WHERE Email = @e", con);
            cmd.Parameters.AddWithValue("@e", email);

            var result = cmd.ExecuteScalar();
            if (result == null) return false;

            string storedPass = result.ToString();
            return storedPass == password;
        }
    }
}
