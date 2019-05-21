using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Comments : IEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
