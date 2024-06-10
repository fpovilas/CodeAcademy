using FinalProject.Shared.CustomExceptions;
using System.Text.RegularExpressions;

namespace FinalProject.Shared.DTOs
{
    public class SignUpUserDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        private readonly string passValidationRegex = @"^(?=.*[A-Z].*[A-Z])(?=.*[a-z].*[a-z])(?=.*\d.*\d)(?=.*[\W_].*[\W_]).{12,}$";

        public bool CheckUsername()
        {
            if (Username.Length < 8)
            { throw new BadUsernameException($"{Username} is too short"); }

            if (Username.Length > 20)
            { throw new BadUsernameException($"{Username} is too long"); }

            return true;
        }

        public bool CheckPassword()
        {
            if (!CheckPasswordRequirements())
            { throw new BadPasswordException($"Password must have atleast 2 UPPERCASE characters, 2 lowercase characters, 2 numbers and 2 special symbols"); }

            return true;
        }

        private bool CheckPasswordRequirements()
            => Regex.IsMatch(Password, passValidationRegex);
    }
}