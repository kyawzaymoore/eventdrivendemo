using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventDrivenDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventDrivenDemo.Controllers
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController : Controller
    {
        private ITransactionService _transactionService;
        private IAuditService _auditService;

        public TransactionController(ITransactionService transactionService, IAuditService auditService)
        {
            _transactionService = transactionService;
            _auditService = auditService;
            _auditService.Subscribe(_transactionService);
        }

        [HttpPost("deposit")]
        public IActionResult MakeDeposit([FromQuery]decimal amount)
        {
            _transactionService.MakeDeposit(amount);
            //_auditService.WriteAuditLog($"Deposit for ${amount} processed"); // old
            return Ok();
        }

        [HttpPost("withdrawal")]
         public IActionResult MakeWithdrawal([FromQuery]decimal amount)
        {
            _transactionService.MakeWithdrawal(amount);
            //_auditService.WriteAuditLog($"Withdrawal for ${amount} processed"); // old
            return Ok();
        }
    }


}