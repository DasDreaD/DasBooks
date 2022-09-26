using Domain.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorById(int id);
        Task<int> CreateAuthor(AuthorForCreation authorForCreation);
    }
}
