using System;
using System.Collections.Generic;
using System.Text;

namespace TeknolojininAdresi.Dto
{
    public class CartLinesDTO
    {
        public int CartLineId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int ProductId { get; set; }
        public int CartsId { get; set; }
    }
}
