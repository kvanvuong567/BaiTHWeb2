using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models;

namespace BTH_BUOI1.Repositories
{
    public interface IPublisherRepository
    {
        List<Publishers> GetAllPublishers();
        Publishers GetPublishersById(int id);
        AddPublisherRequestDTO AddPublishers(AddPublisherRequestDTO addPublisherRequestDTO);
        AddPublisherRequestDTO? UpdatePublisherById(int id, AddPublisherRequestDTO publisherDTO);
        Publishers? DeletePublisherById(int id);
    }
}
