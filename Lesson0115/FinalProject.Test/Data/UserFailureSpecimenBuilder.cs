using AutoFixture.Kernel;
using FinalProject.Database.Entity;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;
using System.Security.Claims;

namespace FinalProject.Test.Data
{
    public class UserFailureSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type t && t == typeof(User))
            {
                return new User
                {
                    Id = 1,
                    Username = "Username",
                    PasswordHash = [],
                    PasswordSalt = [],
                    Role = Roles.Admin.ToString(),
                    PersonalInformations = []
                };
            }

            if (request is Type t2 && t2 == typeof(SignUpUserDTO))
            {
                return new SignUpUserDTO
                {
                    Username = "Username",
                    Password = "Password"
                };
            }

            if (request is Type t3 && t3 == typeof(UserAdminDTO))
            {
                return new UserAdminDTO
                {
                    Id = 1,
                    Username = "Username",
                    Role = Roles.Admin.ToString(),
                    PersonalInformations = []
                };
            }

            if (request is Type t4 && t4 == typeof(Claim))
            {
                return new Claim(ClaimTypes.Role, "User", ClaimValueTypes.String);
            }

            if (request is Type t5 && t5 == typeof(string))
            {
                return "Token";
            }

            return new NoSpecimen();
        }
    }
}
