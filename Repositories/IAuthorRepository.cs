using BTH_BUOI1.Models;
using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;

namespace BTH_BUOI1.Repositories
{
    public interface IAuthorRepository
    {
        List<Authors> GetAllAuthors(SortField sortedBy);
        Authors GetAuthorById(int id);
        AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO);
        AddAuthorRequestDTO? UpdateAuthorById(int id, AddAuthorRequestDTO authorDTO);
        Authors? DeleteAuthorById(int id);
    }
}
