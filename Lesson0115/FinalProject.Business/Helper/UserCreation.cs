using FinalProject.Database.Entity;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;
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

        public static User Create(SignUpUserDTO userDTO)
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new()
            {
                Username = userDTO.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Roles.User.ToString(),
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