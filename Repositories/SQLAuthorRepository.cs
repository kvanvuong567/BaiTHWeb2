using BTH_BUOI1.Data;
using BTH_BUOI1.Models;
using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;

namespace BTH_BUOI1.Repositories
{
    public class SQLAuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLAuthorRepository (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Authors> GetAllAuthors(SortField sortedBy)
        {
            IQueryable<Authors> query = _dbContext.Authors;

            switch (sortedBy)
            {
                case SortField.Name:
                    query = query.OrderBy(author => author.FullName);
                    break;
                case SortField.ID:
                    query = query.OrderBy(author => author.ID);
                    break;
                default:
                    break;
            }

            var allAuthors = query.Select(author => new Authors
            {
                ID = author.ID,
                FullName = author.FullName,
                Book_Authors = author.Book_Authors.ToList()
            })
            .ToList();
            return allAuthors;
        }

        public Authors GetAuthorById(int id)
        {
            var authorWithDomain = _dbContext.Authors.Where(n => n.ID == id);

            var authorWithIdDTO = authorWithDomain.Select(Author => new Authors()
            {
                ID = Author.ID,
                FullName = Author.FullName,
                Book_Authors = Author.Book_Authors.ToList()
            }).FirstOrDefault();
            return authorWithIdDTO;
        }

        public AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO)
        {
            var authorDomainModel = new Authors
            {
               FullName = addAuthorRequestDTO.FullName
            };
            
            _dbContext.Authors.Add(authorDomainModel);
            _dbContext.SaveChanges();
            return addAuthorRequestDTO;
        }

        public AddAuthorRequestDTO? UpdateAuthorById(int id, AddAuthorRequestDTO authorDTO)
        {
            var authorDomain = _dbContext.Authors.FirstOrDefault(n => n.ID == id);
            if (authorDomain != null)
            {
                authorDomain.FullName = authorDTO.FullName;
                _dbContext.SaveChanges();
            }

            // Xóa các liên kết giữa sách và tác giả cũ
            var bookAuthorsToRemove = _dbContext.Book_Authors.Where(a => a.AuthorId == id).ToList();
            if (bookAuthorsToRemove != null)
            {
                _dbContext.Book_Authors.RemoveRange(bookAuthorsToRemove);
                _dbContext.SaveChanges();
            }

            // Thêm các liên kết giữa sách và tác giả mới
            if (authorDTO != null)
            {
                return authorDTO;
            }
            else
            {
                foreach (var authorid in authorDTO.AuthorIds)
                {
                    var _book_author = new Book_Author()
                    {
                        BookId = id,
                        AuthorId = authorid
                    };
                    _dbContext.Book_Authors.Add(_book_author);
                }
                _dbContext.SaveChanges();
                return authorDTO;
            }
        }

        public Authors? DeleteAuthorById(int id)
        {
            var authorDomain = _dbContext.Authors.FirstOrDefault(n => n.ID == id);
            if (authorDomain != null)
            {
                _dbContext.Authors.Remove(authorDomain);
                _dbContext.SaveChanges();
            }
            return authorDomain;
        }
    }
}
