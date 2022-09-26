using AutoMapper;
using Domain.Authors;
using Domain.Books;
using Persistence.DbContexts.DasBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasBooksAPI.MappingProfiles
{
    public class EntityToDomainProfile : Profile
    {
        public EntityToDomainProfile()
        {
            CreateMap<Authors, Author>();

            CreateMap<Books, Book>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.MiddleName} {src.Author.LastName}"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
