using AutoMapper;
using FinalProject.Business.Helper;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;
using System.Security.Claims;

namespace FinalProject.Business.Service
{
    public class UserService(IUserRepository userRepository, IJWTService jwtService, IMapper mapper) : IUserService
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

        public IEnumerable<UserAdminDTO> GetAll(Claim userClaim)
        {
            var role = userClaim.Value;

            if (string.IsNullOrWhiteSpace(role) || role.Equals(Roles.User.ToString())) { throw new Exception("User is not admin"); }

            var users = userRepository.GetAll();

            return mapper.Map<IEnumerable<UserAdminDTO>>(users);
        }

        public UserAdminDTO Get(int idU, Claim userClaim)
        {
            var role = userClaim.Value;

            if (string.IsNullOrWhiteSpace(role) || role.Equals(Roles.User.ToString())) { throw new Exception("User is not admin"); }

            var user = userRepository.Get(idU);

            return mapper.Map<UserAdminDTO>(user);
        }

        public string Delete(int idU, IEnumerable<Claim> claims)
        {
            var role = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role))!.Value;
            var username = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))!.Value;

            var user = userRepository.FindByUsername(username) ?? throw new NoDataException("User does not exist");
            if (user.Id == idU) { throw new Exception("You can not delete yourself"); }

            var userToDelete = userRepository.FindById(idU) ?? throw new NoDataException("User does not exist");

            string deletedUsername = userToDelete.Username ?? throw new NoDataException("No data. Something went wrong.");

            if (userRepository.Delete(userToDelete))
            {
                try
                {
                    if (userToDelete.PersonalInformations is not null)
                    {
                        foreach (var pi in userToDelete.PersonalInformations)
                        {
                            if (pi.ProfilePicturePath is not null)
                            { File.Delete(pi.ProfilePicturePath); }
                            else { continue; }
                        }
                    }

                    return deletedUsername;
                }
                catch { throw new Exception("Could not delete profile pictures"); }
            }
            else { throw new Exception($"Could not delete user {deletedUsername}. Something went wrong"); }
        }
    }
}
