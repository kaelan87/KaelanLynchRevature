using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using TheParisCreperie.Models;
//using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TheParisCreperie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        CustomerModel customer = new CustomerModel();
        /*public CustomerDetailsController(ILogger<CustomerDetailsController> logger)
        {
            ILogger _logger = logger;
           
        
}*/
        [HttpGet]
        [Route("customerlist")]
        public IActionResult Customerlist()
        {
            
            return Ok(customer.GetCustomerList());
        }

        [HttpGet()]
        [Route("customerid")]
        public IActionResult GetCustomerById(int customerid)
        {
            try
            {
                return Ok(customer.GetCustomerDetails(customerid));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }


        [HttpPost()]
        [Route("newCustomer")]
        public IActionResult Addcustomer(CustomerModel newCustomer)
        {
            try
            {
                return Created("", customer.Addcustomer(newCustomer));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }

        }

        [HttpDelete()]
        [Route("customerid")]
        public IActionResult Deletecustomer(int customerid)
        {
            try
            {
                return Accepted(customer.Deletecustomer(customerid));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpPut ()]
        [Route("updates")]
        public IActionResult Updatecustomer(CustomerModel updates)
        {
            try
            {
                return Accepted(customer.Updatecustomer(updates));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }

    }
}

