using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _repComments;

        public CommentsService(ICommentsRepository repComments)
        {
            _repComments = repComments;
        }

        public void AddComment(Comments comment)
        {
            _repComments.Add(comment);
        }

        public async Task<List<Comments>> GetCommentsByProId(int productId)
        {
            return await _repComments.GetList(x=> x.ProductsId == productId);
        }
    }
}
