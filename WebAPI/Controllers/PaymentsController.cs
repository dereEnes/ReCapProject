using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentService _paymentService;
        private ICreditCardService _creditCardService;
        
        public PaymentsController(IPaymentService paymentService, ICreditCardService creditCardService)
        {
            _paymentService = paymentService;
            _creditCardService = creditCardService;
        }

        [HttpPost("add")]
        public IActionResult AddPayment(CreditCard payment)
        {
            var result = _creditCardService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
