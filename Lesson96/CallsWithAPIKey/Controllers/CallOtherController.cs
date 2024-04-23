using CallsWithAPIKey.Extension.Interface;
using CallsWithAPIKey.Models;
using CallsWithAPIKey.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CallsWithAPIKey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallOtherController(IHttpClientExtension httpClientExtension) : ControllerBase
    {
        [HttpGet("ExternalCall")]
        public async Task<ActionResult<UserJWTToken>> Get(string user, string pass, string apiKey)
        {
            var jwt = await httpClientExtension.GetJWTToken(user, pass, apiKey);
            if (string.IsNullOrEmpty(jwt.JWTToken))
                return BadRequest();

            return Ok(jwt.JWTToken);
        }

        [HttpGet("ExternalGetCarsCall")]
        public async Task<ActionResult<List<CarDto>>> GetCars(string jwtToken)
        {
            List<CarDto> carsList = await httpClientExtension.GetCars(jwtToken);
            if (carsList.Count == 0)
                return BadRequest();

            return Ok(carsList);
        }
    }
}