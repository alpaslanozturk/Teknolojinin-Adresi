using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersService _serviceOrder;
        private ICartsService _serviceCarts;

        public OrdersController(IOrdersService serviceOrder, ICartsService serviceCarts)
        {
            _serviceOrder = serviceOrder;
            _serviceCarts = serviceCarts;
        }

        [HttpPost("completeOrder")]
        public async Task<IActionResult> CompleteOrder(int userId, int cartsId, [FromBody] Orders order)
        {
            _serviceOrder.CompleteOrder(userId, cartsId, order);
            _serviceCarts.OffCart(cartsId);

            return Ok();
        }
    }
}