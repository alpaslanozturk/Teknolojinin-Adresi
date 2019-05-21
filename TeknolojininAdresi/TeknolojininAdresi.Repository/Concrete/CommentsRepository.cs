using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Core.Repository.EntityFramework;
using TeknolojininAdresi.DataAccess.Context;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Repository.Concrete
{
    public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(TeknolojininAdresiContext context) : base(context)
        {

        }

    }
}
