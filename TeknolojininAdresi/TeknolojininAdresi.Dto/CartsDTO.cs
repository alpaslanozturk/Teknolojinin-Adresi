using System;
using System.Collections.Generic;
using System.Text;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Dto
{
    public class CartsDTO
    {
        public class CartMainDTO
        {
            public int CartId { get; set; }
            public decimal TotalPrice { get; set; }
            public bool IsMain { get; set; }
        }
    }
}
