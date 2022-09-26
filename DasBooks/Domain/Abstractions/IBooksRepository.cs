using Domain.Books;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IBooksRepository
    {
        Task<Book> GetBookById(int id);

        Task<int?> CreateBook(BookForCreation book);
    }
}
