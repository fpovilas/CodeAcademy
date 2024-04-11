using Atm.Interfaces;
using Atm.Model;
using Microsoft.AspNetCore.Mvc;

namespace Atm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("CreateTransaction")]
        public void CreateTransaction([FromBody] Transaction transaction)
        {
            _transactionService.CreateTransaction(transaction);
        }

        [HttpGet("GetTransactionsDetails/{CustomerKey}")]
        public ActionResult<string> GetTransactionDetails([FromRoute] string CustomerKey, [FromQuery] string accountNo, [FromQuery] int limit)
        {
            try
            {
                var result = _transactionService.GetTransactionDetails(accountNo, CustomerKey, limit);
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
    }
}
