using AutoMapper;
using Domain.Authors;
using Domain.Books;
using Persistence.DbContexts.DasBooks;

namespace DasBooksAPI.MappingProfiles
{
    public class DomainToEntityProfile : Profile
    {
        public DomainToEntityProfile()
        {
            CreateMap<BookForCreation, Books>();
            CreateMap<AuthorForCreation, Authors>();
        }
    }
}
