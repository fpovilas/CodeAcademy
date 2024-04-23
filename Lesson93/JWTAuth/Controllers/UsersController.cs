using Microsoft.AspNetCore.Mvc;
using JWTAuth.DB;
using JWTAuth.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using JWTAuth.Models;
using JWTAuth.Attributes;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserContext userContext, IJWTService jwtService) : Controller
    {
        [HttpPost("SignUp")]
        public User SignUp(string username, string password)
        {
            var user = CreateUser(username, password);
            userContext.Add(user);
            userContext.SaveChanges();
            return user;
        }

        [ApiKeyAuth]
        [HttpPost("LogIn")]
        public ActionResult LogIn(string username, string password)
        {
            var user = userContext.Users.FirstOrDefault(x => x.Username == username);
            if (VerifyPassword(password, user!.PasswordHash, user.PasswordSalt))
            {
                var role = user.Role;
                return Ok(jwtService.GetJWT(username, role));
            }

            return Unauthorized();
        }

        [HttpPost("ChangeRole")]
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeRole(string username, string newRole)
        {
            var user = userContext.Users.FirstOrDefault(u => u.Username.Equals(username));
            if (user is null) BadRequest($"User with username {username} does not exist");

            string msg;
            if (newRole.Equals(user!.Role)) msg = $"User alread is {newRole}";
            else
            {
                msg = $"User role from {user!.Role} changed to {newRole}";
                user.Role = newRole;
                userContext.Users.Update(user);
            }
            userContext.SaveChanges();
            return Ok(msg);
        }

        [HttpGet("GetUser")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetUser(string username)
        {
            var user = userContext.Users.FirstOrDefault(x => x.Username == username);

            return Ok(user);
        }

        #region Supporting Methods For User Creation

        private static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new()
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User"
            };
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        #endregion
    }
}
