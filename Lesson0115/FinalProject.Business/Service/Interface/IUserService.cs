using FinalProject.Shared.DTOs;
using System.Security.Claims;

namespace FinalProject.Business.Service.Interface
{
    public interface IUserService
    {
        string Delete(int idU, IEnumerable<Claim> claims);
        UserAdminDTO Get(int idU, Claim userClaim);
        IEnumerable<UserAdminDTO> GetAll(Claim userClaim);
        string LogIn(SignUpUserDTO userDTO);
        void SignUp(SignUpUserDTO userDTO);
    }
}
