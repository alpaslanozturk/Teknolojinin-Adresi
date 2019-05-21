using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Dto;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private IMapper _mapper;
        private ICartLinesService _serviceCartLines;
        private IAuthService _authService;
        private ICartsService _serviceCarts;

        public CartsController(IMapper mapper, ICartLinesService serviceCartLines, IAuthService authService,
            ICartsService serviceCarts)
        {
            _mapper = mapper;
            _serviceCartLines = serviceCartLines;
            _authService = authService;
            _serviceCarts = serviceCarts;
        }

        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart(int userId, int quantity, [FromBody] Products product)
        {
            Users user = await _authService.GetUser(userId);
            Carts cart = await _serviceCarts.GetCart(userId);
            _serviceCartLines.AddToCart(cart, product, quantity);

            return Ok();
        }

        [HttpGet("removeToCart")]
        public async Task<IActionResult> RemoveToCart(int userId, int productId)
        {
            Users user = await _authService.GetUser(userId);
            Carts cart = await _serviceCarts.GetCart(userId);
            _serviceCartLines.RemoveToCart(cart, productId);

            return Ok();
        }

        [HttpGet("getMainCart")]
        public async Task<IActionResult> GetMainCart(int userId)
        {
            Carts cart = await _serviceCarts.GetCart(userId);
            List<CartLinesDTO> dto = _mapper.Map<List<CartLinesDTO>>(await _serviceCartLines.GetCartLinesList(cart));     
            
            return Ok(dto);                       
        }
        
    }
}