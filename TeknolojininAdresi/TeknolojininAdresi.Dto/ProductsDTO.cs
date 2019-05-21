using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeknolojininAdresi.Dto
{
    public class ProductsDTO
    {
        public class ProductsHomeDTO
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public Nullable<decimal> Discount { get; set; }
            public string PictureUrl { get; set; }
            public DateTime AddedDate { get; set; }
            public decimal TotalRating { get; set; }
            public string CategoryName { get; set; }
        }

        public class AddProductDTO
        {
            public int? ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public Nullable<decimal> OldPrice { get; set; }
            public int UnitsInStock { get; set; }
            public string PictureUrl { get; set; }
            public int SellCount { get; set; }
            public int CategoriesId { get; set; }
        }

        public class ProductsListAdminDTO
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public Nullable<decimal> OldPrice { get; set; }
            public int UnitsInStock { get; set; }
            public int SellCount { get; set; }
            public DateTime AddedDate { get; set; }
        }

    }
}
