﻿using Business.Abstract;
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
        
        
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
            
        }

        [HttpPost("add")]
        public IActionResult AddPayment(Collection collection)
        {
            var result = _paymentService.Add(collection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
