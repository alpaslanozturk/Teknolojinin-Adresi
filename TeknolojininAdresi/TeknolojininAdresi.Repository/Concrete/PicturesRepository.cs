using System;
using System.Collections.Generic;
using System.Text;
using TeknolojininAdresi.Core.Repository.EntityFramework;
using TeknolojininAdresi.DataAccess.Context;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Repository.Concrete
{
    public class PicturesRepository : BaseRepository<Pictures>, IPicturesRepository
    {
        public PicturesRepository(TeknolojininAdresiContext context) : base(context)
        {

        }
    }
}
