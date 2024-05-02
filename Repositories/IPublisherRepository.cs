using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models;
using BTH_BUOI1.Models.Sorted;

namespace BTH_BUOI1.Repositories
{
    public interface IPublisherRepository
    {
        List<Publishers> GetAllPublishers(SortField sortedBy);
        Publishers GetPublishersById(int id);
        AddPublisherRequestDTO AddPublishers(AddPublisherRequestDTO addPublisherRequestDTO);
        AddPublisherRequestDTO? UpdatePublisherById(int id, AddPublisherRequestDTO publisherDTO);
        Publishers? DeletePublisherById(int id);
    }
}
