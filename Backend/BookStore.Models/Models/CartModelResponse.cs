using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class CartModelResponse
    {
        public CartModelResponse() { }
        public CartModelResponse(Cart cart)
        {
            Id = cart.Id;
            UserId = cart.Userid;
            BookId = cart.Bookid;
            Quantity = cart.Quantity;
            this.Price = cart.Book.Price;
            this.Base64image = cart.Book.Base64image;
            this.Name = cart.Book.Name;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Base64image { get; set; }
        public string Name { get; set; }
    }
}
