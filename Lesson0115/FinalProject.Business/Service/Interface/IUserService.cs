using FinalProject.Shared.DTOs;

namespace FinalProject.Business.Service.Interface
{
    public interface IUserService
    {
        string LogIn(SignUpUserDTO userDTO);
        void SignUp(SignUpUserDTO userDTO);
    }
}
