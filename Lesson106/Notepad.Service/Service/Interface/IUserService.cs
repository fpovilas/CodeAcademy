using Notepad.Shared.Dto;

namespace Notepad.Service.Service.Interface
{
    public interface IUserService
    {
        public bool Register(string username, string password, out UserDto user);
        public bool LogIn(string username, string password, out string jwt);
    }
}