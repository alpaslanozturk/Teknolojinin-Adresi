using System;
using System.Collections.Generic;
using System.Text;

namespace TeknolojininAdresi.Dto
{
    public class CommentsDTO
    {
        public class CommentsProductsDTO
        {
            public int CommentId { get; set; }
            public string Comment { get; set; }
            public decimal Rating { get; set; }

        }

        public class CommentsAddDTO
        {
            public int CommentId { get; set; }
            public string Comment { get; set; }
            public decimal Rating { get; set; }
            public int ProductsId { get; set; }

        }
    }
}
