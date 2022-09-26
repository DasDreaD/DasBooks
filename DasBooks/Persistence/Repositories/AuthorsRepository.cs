using AutoMapper;
using Domain.Abstractions;
using Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.DasBooks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DasBooksDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(DasBooksDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAuthor(AuthorForCreation authorForCreation)
        {
            var entity = _mapper.Map<Authors>(authorForCreation);
            _context.Set<Authors>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.AuthorId;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return _mapper.Map<Author>(author);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<IEnumerable<Author>>(authors);
        }
    }
}
