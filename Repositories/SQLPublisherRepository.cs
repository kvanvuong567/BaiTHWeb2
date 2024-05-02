using BTH_BUOI1.Data;
using BTH_BUOI1.Models;
using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models.DTO;

namespace BTH_BUOI1.Repositories
{
    public class SQLPublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLPublisherRepository (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Publishers> GetAllPublishers()
        {
            var AllPublishers = _dbContext.Publishers.Select(publisher => new Publishers()
            {
                ID = publisher.ID,
                Name = publisher.Name,
                //Books = publisher.Books.Select(book => book.ID).ToList()
            }).ToList();

            return AllPublishers;
        }
        public Publishers GetPublishersById(int id)
        {
            var publisherWithDomain = _dbContext.Publishers.Where(n => n.ID == id);

            var publisherWithIdDTO = publisherWithDomain.Select(publishers => new Publishers()
            {
                ID = publishers.ID,
                Name = publishers.Name,
            }).FirstOrDefault();
            return publisherWithIdDTO;
        }

        public AddPublisherRequestDTO AddPublishers (AddPublisherRequestDTO addPublisherRequestDTO)
        {
            var publisherDomainModel = new Publishers
            {
                Name = addPublisherRequestDTO.Name,
            };

            _dbContext.Publishers.Add(publisherDomainModel);
            _dbContext.SaveChanges();
            return addPublisherRequestDTO;
        }

        public AddPublisherRequestDTO? UpdatePublisherById(int id, AddPublisherRequestDTO publisherDTO)
        {
            var publisherDomain = _dbContext.Publishers.FirstOrDefault(n => n.ID == id);
            if (publisherDomain != null)
            {
                publisherDomain.Name = publisherDTO.Name;
                _dbContext.SaveChanges();
            }

            // Xóa các liên kết giữa nhà xuất bản và sách cũ
            var booksToRemove = _dbContext.Books.Where(b => b.PublisherId == id).ToList();
            if (booksToRemove != null)
            {
                foreach (var book in booksToRemove)
                {
                    book.PublisherId = null; 
                }
                _dbContext.SaveChanges();
            }

            // Thêm các liên kết giữa sách và nhà xuất bản mới
            if (publisherDTO != null)
            {
                return publisherDTO;
            }
            else
            {
                foreach (var bookId in publisherDTO.BookIds)
                {
                    var book = _dbContext.Books.FirstOrDefault(b => b.ID == bookId);
                    if (book != null)
                    {
                        book.PublisherId = id;
                    }
                }
                _dbContext.SaveChanges();
            }
            return publisherDTO;
        }

        public Publishers? DeletePublisherById(int id)
        {
            var publisherDomain = _dbContext.Publishers.FirstOrDefault(n => n.ID == id);
            if (publisherDomain != null)
            {
                _dbContext.Publishers.Remove(publisherDomain);
                _dbContext.SaveChanges();
            }
            return publisherDomain;
        }
    }
}
