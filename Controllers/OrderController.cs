using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheParisCreperie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrdersModel orders = new OrdersModel();

        [HttpGet]
        [Route("Orderlist")]
        public IActionResult Orderlist()
        {
            return Ok(orders.GetOrderlist());
        }

        [HttpGet()]
        [Route("orderNo")]
        public IActionResult GetOrderDetails(int orderNo)
        {
            try
            {
                return Ok(orders.GetOrderDetails(orderNo));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }
        [HttpGet()]
        [Route("customerid")]
        public IActionResult GetCustomerOrders(int customerid)
        {
            try
            {
                return Ok(orders.GetCustomerOrders(customerid));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }


        [HttpPost()]
        [Route("newOrder")]
        public IActionResult Addorder(OrdersModel newOrder)
        {
            try
            {
                return Created("", orders.Addorder(newOrder));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }

        }

        [HttpDelete()]
        [Route("orderNo")]
        public IActionResult cancelorder(int orderNo)
        {
            try
            {
                return Accepted(orders.CancelOrder(orderNo));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpPut()]
        [Route("updates")]
        public IActionResult Updatecustomer(OrdersModel updates)
        {
            try
            {
                return Accepted(orders.Updateorder(updates));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }

    }
}
