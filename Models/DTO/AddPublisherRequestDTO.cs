using System.ComponentModel.DataAnnotations;

namespace BTH_BUOI1.Models.DTO
{
    public class AddPublisherRequestDTO
    {
        [Key]
        public string? Name { get; set; }

        public List<int> BookIds { get; set; }
    }
}
