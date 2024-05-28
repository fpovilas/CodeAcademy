using FinalProject.Database.Models;
using System.Security.Cryptography;

namespace FinalProject.Business.Helper
{
    public static class UserCreation
    {
        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public static User Create(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new()
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User",
                PersonalInformations = []
            };
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
    }
}