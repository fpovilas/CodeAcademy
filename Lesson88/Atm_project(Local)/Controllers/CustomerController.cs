using Atm.Dto;
using Atm.Interfaces;
using Atm.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Atm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService _customerService) : ControllerBase
    {
        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] CustomerLoginDto customer)
        {
            try
            {
                var result = _customerService.Login(customer);
                return Ok(result);
            }
            catch (ArgumentNullException Ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, Ex.Message);
            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, Ex.Message);
            }
        }

        [HttpPost("CreateCustomer")]
        public ActionResult<Customer> CreateCustomer([FromBody] CustomerDto customerDto, [FromQuery][Required] string userName, [FromQuery][Required] string pass)
        {
            try
            {
                Customer customerToCreate = _customerService.CreateCustomer(customerDto, userName, pass);
                if (customerToCreate is not null)
                    return Ok(customerToCreate);
                else return BadRequest(customerDto);
            }
            catch { return BadRequest(new()); }
        }
    }
}