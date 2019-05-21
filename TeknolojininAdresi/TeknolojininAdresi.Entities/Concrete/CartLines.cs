using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class CartLines : IEntity
    {
        [Key]
        public int CartLineId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }

        public int CartsId { get; set; }
        public Carts Carts { get; set; }
    }
}
