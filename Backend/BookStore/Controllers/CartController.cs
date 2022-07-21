using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Respositary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new CartRepository();
       
    /*    [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(string keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c)); 
            return Ok(cartModels);
        } */

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems2(int UserId)
        {
            var cartitem = _cartRepository.GetCartListall(UserId);
            ListResponse<CartModelResponse> listResponse = new ListResponse<CartModelResponse>()
            {
                Results = cartitem.Results.Select(c => new CartModelResponse(c)),
                TotalRecords = cartitem.TotalRecords,
            };
           
            return Ok(listResponse);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();
           
            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.BookId,
                Userid = model.UserId
            };
            cart = _cartRepository.AddCart(cart);
            CartModel cartmodel = new CartModel(cart);

            return Ok(cartmodel);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.BookId,
                Userid = model.UserId
            };
            cart = _cartRepository.UpdateCart(cart);
            CartModel cartmodel = new CartModel(cart);

            return Ok(cartmodel);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest();

            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
