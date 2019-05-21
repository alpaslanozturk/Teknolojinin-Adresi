using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeknolojininAdresi.Business.Abstract;
using TeknolojininAdresi.Entities.Concrete;
using TeknolojininAdresi.Repository.Abstract;

namespace TeknolojininAdresi.Business.Concrete
{
    public class PicturesService : IPicturesService
    {
        private IPicturesRepository _repPicture;

        public PicturesService(IPicturesRepository repPicture)
        {
            _repPicture = repPicture;
        }

        public async Task<List<Pictures>> GetPicturesByProId(int productId)
        {
            return await _repPicture.GetList(x=> x.ProductsId == productId);
        }
    }
}
