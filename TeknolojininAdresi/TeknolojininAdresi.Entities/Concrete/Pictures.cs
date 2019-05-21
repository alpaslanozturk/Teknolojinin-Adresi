using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeknolojininAdresi.Core.Entities;

namespace TeknolojininAdresi.Entities.Concrete
{
    public class Pictures : IEntity
    {
        [Key]
        public int PictureId { get; set; }
        public string PictureUrl { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}
