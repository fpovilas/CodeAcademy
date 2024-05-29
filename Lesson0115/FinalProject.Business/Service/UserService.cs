using FinalProject.Business.Helper;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;

namespace FinalProject.Business.Service
{
    public class UserService(IUserRepository userRepository, IJWTService jwtService) : IUserService
    {
        public void SignUp(SignUpUserDTO userDTO)
        {
            User user = UserCreation.Create(userDTO);
            userRepository.SignUp(user);
        }

        public string LogIn(SignUpUserDTO userDTO)
        {
            try
            {
                var user = userRepository.FindByUsername(userDTO.Username);
                if (user is not null)
                {
                    if (!UserCreation.VerifyPassword(userDTO.Password, user.PasswordHash ?? new byte[1], user.PasswordSalt ?? new byte[1]))
                    { throw new BadPasswordException("You have entered bad password"); }
                    return jwtService.GetJWT(userDTO.Username, user.Role ?? Roles.User.ToString());
                }
                else { throw new Exception("User does not exists."); }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
