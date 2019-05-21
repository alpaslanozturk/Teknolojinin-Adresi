using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Carts : IEntity
    {
        [Key]
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsMain { get; set; }

        public int? UsersId { get; set; }
        public Users Users { get; set; }

        public ICollection<CartLines> CartLines { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
