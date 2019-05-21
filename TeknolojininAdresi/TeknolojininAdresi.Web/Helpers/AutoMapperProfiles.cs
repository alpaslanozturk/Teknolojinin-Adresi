using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeknolojininAdresi.Dto;
using TeknolojininAdresi.Entities.Concrete;
using static TeknolojininAdresi.Dto.CategoriesDTO;
using static TeknolojininAdresi.Dto.CommentsDTO;
using static TeknolojininAdresi.Dto.PicturesDTO;
using static TeknolojininAdresi.Dto.ProductsDTO;

namespace TeknolojininAdresi.Web.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<City, CityForListDto>()
            //    .ForMember(dest => dest.PhotoUrl, opt =>
            //    {
            //        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            //    });

            CreateMap<Categories, CategoriesHomeDTO>();
            CreateMap<Products, ProductsHomeDTO>().ForMember(dest => dest.CategoryName, opt =>
                {
                    opt.MapFrom(src => src.Categories.CategoryName);
                })
                .ForMember(dest => dest.TotalRating, opt =>
                {
                    opt.MapFrom(src => (src.Comments.Count > 0) ? ((src.Comments.Sum(x => x.Rating) / src.Comments.Count)) : 1);
                });


            CreateMap<Categories, CategoriesListDTO>().ForMember(dest => dest.ProductsCount, opt =>
            {
                opt.MapFrom(src => src.Products.Count);
            }); 
            CreateMap<Categories, CategoriesListHomeDTO>();
            CreateMap<Comments, CommentsProductsDTO>();
            CreateMap<Pictures, PicturesProductDTO>();
            CreateMap<CommentsAddDTO, Comments>();

            CreateMap<CartLines, CartLinesDTO>().ForMember(dest => dest.ProductName, opt =>
            {
                opt.MapFrom(src => src.Products.ProductName);
            })
            .ForMember(dest => dest.ProductId, opt =>
            {
                opt.MapFrom(src => src.Products.ProductId);
            })
            .ForMember(dest => dest.PictureUrl, opt =>
            {
                opt.MapFrom(src => src.Products.PictureUrl);
            });

            CreateMap<AddProductDTO, Products>(); 
            CreateMap<CategoriesListAdminDTO, Categories>();
        }
    }
}
