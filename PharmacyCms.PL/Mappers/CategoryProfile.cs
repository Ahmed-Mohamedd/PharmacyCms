using AutoMapper;
using Pharmacy.DAL.Entities;
using Pharmacy.PL.Models;

namespace Pharmacy.PL.Mappers
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>().ReverseMap();
        }
    }
}
