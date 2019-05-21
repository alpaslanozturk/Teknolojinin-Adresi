using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Entities.Concrete;

namespace TeknolojininAdresi.Business.Abstract
{
    public interface IPicturesService
    {
        Task<List<Pictures>> GetPicturesByProId(int productId);
    }
}
