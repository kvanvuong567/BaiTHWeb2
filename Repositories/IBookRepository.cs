using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;
namespace BTH_BUOI1.Repositories
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO> GetAllBooks(SortField sortedBy);
        BookWithAuthorAndPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
        AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Books? DeleteBookById(int id);
    }
}
