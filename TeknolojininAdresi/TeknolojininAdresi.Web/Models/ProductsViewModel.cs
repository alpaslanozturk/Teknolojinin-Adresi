using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TeknolojininAdresi.Dto.ProductsDTO;

namespace TeknolojininAdresi.Web.Models
{
    public class ProductsViewModel
    {
        public List<ProductsHomeDTO> dto { get; set; }
        public int pageCount { get; set; }
    }
}
