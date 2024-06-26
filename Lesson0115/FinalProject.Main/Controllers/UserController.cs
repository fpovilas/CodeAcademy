﻿using FinalProject.Business.Service.Interface;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        // POST: api/User/SignUp
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("SignUp")]
        public ActionResult<SignUpUserDTO> SignUp([FromForm] SignUpUserDTO user)
        {
            try
            {
                if (user.CheckUsername() && user.CheckPassword())
                {
                    userService.SignUp(user);
                }
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(user.Username);
        }

        // POST: api/User/LogIn
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("LogIn")]
        public ActionResult LogIn([FromForm] SignUpUserDTO user)
        {
            string jwt;
            try
            {
                jwt = userService.LogIn(user);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(jwt);
        }

        // GET: api/User/AdminGetAll
        [Authorize(Roles = "Admin")]
        [HttpGet("AdminGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<UserAdminDTO>> GetALL()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            try
            {
                if (userClaim is null)
                { return BadRequest("Please log in."); }

                var value = userService.GetAll(userClaim);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // GET: api/User/AdminGetById/5
        [HttpGet("AdminGetById/{idU}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UserAdminDTO> GetById(int idU)
        {
            try
            {
                var userClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (userClaim is null)
                { return BadRequest("Please log in."); }

                return Ok(userService.Get(idU, userClaim));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // DELETE: api/User/AdminDelete/5
        [HttpDelete("AdminDelete/{idU}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletePersonalInformation(int idU)
        {
            string deletedUsername = string.Empty;
            try
            {
                var userClaim = User.Claims;
                if (userClaim is not null)
                { deletedUsername = userService.Delete(idU, userClaim); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Successfully deleted {deletedUsername}");
        }
    }
}