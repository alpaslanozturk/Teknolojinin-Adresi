using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TeknolojininAdresi.Dto.CategoriesDTO;
using static TeknolojininAdresi.Dto.ProductsDTO;

namespace TeknolojininAdresi.Web.Models
{
    public class IndexViewModel
    {
        public List<CategoriesHomeDTO> CategoriesList { get; set; }
        public List<ProductsHomeDTO> ProductsListByCategoryId { get; set; }
    }
}
