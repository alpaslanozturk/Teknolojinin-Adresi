using System;
using System.Collections.Generic;
using System.Text;

namespace TeknolojininAdresi.Dto
{
    public class CategoriesDTO
    {
        public class CategoriesHomeDTO
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string PictureUrl { get; set; }
        }

        public class CategoriesListDTO
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public int ProductsCount { get; set; }
        }

        public class CategoriesListHomeDTO
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
        public class CategoriesListAdminDTO
        {
            public int? CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public string PictureUrl { get; set; }
        }

        
    }
}
