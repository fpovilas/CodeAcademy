using AutoMapper;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using System.Security.Claims;

namespace FinalProject.Business.Service
{
    public class AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IMapper mapper) : IAdminService
    {
        public IEnumerable<UserAdminDTO> GetAll(Claim userClaim)
        {
            var role = userClaim.Value;

            if (string.IsNullOrWhiteSpace(role)) { throw new Exception("User is not admin"); }

            var users = adminRepository.GetAll();

            return mapper.Map<IEnumerable<UserAdminDTO>>(users);
        }

        public UserAdminDTO Get(int idU, Claim userClaim)
        {
            var role = userClaim.Value;

            if (string.IsNullOrWhiteSpace(role)) { throw new Exception("User is not admin"); }

            var user = adminRepository.Get(idU);

            return mapper.Map<UserAdminDTO>(user);
        }

        public string Delete(int idU, IEnumerable<Claim> claims)
        {
            var role = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role))!.Value;
            var username = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))!.Value;

            var userAdmin = userRepository.FindByUsername(username) ?? throw new NoDataException("User does not exist");
            if (userAdmin.Id == idU) { throw new Exception("You can not delete yourself"); }

            var userDelete = userRepository.FindById(idU) ?? throw new NoDataException("User does not exist");

            string deletedUsername = userAdmin.Username ?? throw new NoDataException("No data. Something went wrong.");

            return deletedUsername;
        }
    }
}
