using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheParisCreperie.Models;
using System;


namespace TheParisCreperie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        MenuModel menu = new MenuModel();

        #region Menu list
        [HttpGet]
        [Route("Menulist")]
        public IActionResult MenuList()
        {
            MenuModel model = new MenuModel();
            return Ok(model.GetMenulist());
        }

        #endregion


        [HttpPost()]
        [Route("newitem")]
        public IActionResult Additem(MenuModel newitem)
        {
            try
            {
                return Created("", menu.Additem(newitem));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }

        }

        [HttpDelete()]
        [Route("itemNo")]
        public IActionResult Deleteitem(int itemNo)
        {
            try
            {
                return Accepted(menu.Deleteitem(itemNo));
            }
            catch (System.Exception es)
            {
                return BadRequest(es.Message);
            }
        }


        [HttpPut()]
        [Route("updates")]
        public IActionResult Updateitem(MenuModel updates)
        {
            try
            {
                return Accepted(menu.Updateitem(updates));
            }
            catch (System.Exception es)
            {

                return BadRequest(es.Message);
            }
        }

    }
}

