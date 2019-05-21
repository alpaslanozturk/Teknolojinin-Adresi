using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Products : IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string PictureUrl { get; set; }
        public int SellCount { get; set; }
        public DateTime AddedDate { get; set; }

        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }

        public ICollection<Pictures> Pictures { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<CartLines> CartLines { get; set; }

    }
}
