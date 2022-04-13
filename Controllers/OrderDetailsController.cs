using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheParisCreperie.Models;

namespace TheParisCreperie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        OrderDetailsModel OrderDetails = new OrderDetailsModel();
        OrdersModel omodel = new OrdersModel();
        MenuModel mmodel = new MenuModel();

        [HttpGet()]
        [Route("orderNo")]
        public IActionResult GetOrderDetails()
        {
            try
            {
                return Ok(OrderDetails.GetOrderDetails(omodel.orderNo));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }


        [HttpPost()]
        [Route("OrderDetails")]
        public IActionResult AddOrderDetails(OrderDetailsModel newOrderDetails)
        {
            try
            {
                return Created("", OrderDetails.AddOrderDetails(OrderDetails));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }

        }

        [HttpDelete()]
        [Route("orderNo")]
        public IActionResult DeleteOrderDetails(int orderNo)
        {
            try
            {
                return Accepted(OrderDetails.DeleteOrderDetails(omodel.orderNo));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpPut()]
        [Route("updates")]
        public IActionResult UpdateOrderDetails(OrderDetailsModel updates)
        {
            try
            {
                return Accepted(OrderDetails.UpdateOrderDetails(updates));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }
    }
}
