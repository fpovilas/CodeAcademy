using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Helper;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Service.Service
{
    public class UserService(IUserRepository userRepository, IJWTService jwtService) : IUserService
    {
        public bool Register(string username, string password, out UserDto userDto)
        {
            userDto = new UserDto
            {
                Username = username,
                Role = "User",
                Notes = []
            };

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            { return false; }

            User user = UserCreation.Create(username, password);
            userRepository.Register(user);

            return true;
        }

        public bool LogIn(string username, string password, out string jwt)
        {
            jwt = string.Empty;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            { return false; }

            var user = userRepository.FindByUsername(username);
            if(!UserCreation.VerifyPassword(password, user.PasswordHash ?? new byte[1], user.PasswordSalt ?? new byte[1]))
            { return false; }

            jwt = jwtService.GetJWT(username, user.Role ?? "User");
            return true;
        }
    }
}
