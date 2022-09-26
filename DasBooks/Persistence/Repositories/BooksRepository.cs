using AutoMapper;
using Domain.Abstractions;
using Domain.Books;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.DasBooks;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IMapper _mapper;
        private readonly DasBooksDbContext _context;

        public BooksRepository(IMapper mapper, DasBooksDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int?> CreateBook(BookForCreation book)
        {
            var authorExists = _context.Set<Authors>()
                                       .Find(book.AuthorId) != null;
            var categoryExists = _context.Set<BookCategories>()
                                         .Find(book.CategoryId) != null;
            if (authorExists && categoryExists)
            {
                var bookEntity = _mapper.Map<Books>(book);
                _context.Set<Books>().Add(bookEntity);
                await _context.SaveChangesAsync();
                return bookEntity.AuthorId;
            }
            return null;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Set<Books>().AsNoTracking()
                                     .Include(m => m.Author).AsNoTracking()
                                     .Include(m => m.Category).AsNoTracking()
                                     .SingleOrDefaultAsync(param => param.BookId == id);
            return _mapper.Map<Book>(book);
        }
    }
}
