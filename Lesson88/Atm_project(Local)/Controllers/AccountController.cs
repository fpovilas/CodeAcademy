using Atm.Interfaces;
using Atm.Model;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("TransferMoney/{CustomerKey}")]
        public ActionResult<string> Transfer([FromRoute] string CustomerKey, [FromQuery] string toAccountNo, [FromQuery] float amount)
        {
            try
            {
                var result = _accountService.Transfer(CustomerKey, toAccountNo, amount);
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

        [HttpPost("GetAccountDetails")]
        public ActionResult<Account> GetAccountDetails([FromQuery] string customerKey, [FromQuery] string accountNumber)
        {
            try
            {
                var result = _accountService.GetAccountDetails(customerKey, accountNumber);
                return Ok(result);
            }
            catch (ArgumentNullException Ex)
            {
                return BadRequest(Ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Withdraw")]
        public ActionResult<Account> Withdraw([FromQuery] string CustomerKey, [FromQuery] string accountNumber, [FromQuery] float amount)
        {
            try
            {
                var result = _accountService.Withdraw(CustomerKey, accountNumber, amount);
                return Ok(result);
            }
            catch (ArgumentNullException Ex)
            {
                return BadRequest(Ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Deposit")]
        public ActionResult<Account> Deposit([FromQuery] string CustomerKey, [FromQuery] string accountNumber, [FromQuery] float amount)
        {
            try
            {
                var result = _accountService.Deposit(CustomerKey, accountNumber, amount);
                return Ok(result);
            }
            catch (ArgumentNullException Ex)
            {
                return BadRequest(Ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
