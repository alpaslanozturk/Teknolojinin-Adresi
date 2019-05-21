using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetCommentsByProId(int productId);
        void AddComment(Comments comment);
    }
}
