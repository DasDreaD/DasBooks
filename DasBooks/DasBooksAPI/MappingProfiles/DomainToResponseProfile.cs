using Application.Contracts.Response;
using AutoMapper;
using Domain.Authors;
using Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasBooksAPI.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Author, GetAuthorResponse>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(source => DateTime.Now.Year - source.DateOfBirth.Year));

            CreateMap<Book, GetBookResponse>();
        }
    }
}
