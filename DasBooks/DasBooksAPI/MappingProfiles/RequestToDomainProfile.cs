using Application.Contracts.Request;
using AutoMapper;
using Domain.Authors;
using Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasBooksAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateBookRequest, BookForCreation>();
            CreateMap<CreateAuthorRequest, AuthorForCreation>();
        }
    }
}
