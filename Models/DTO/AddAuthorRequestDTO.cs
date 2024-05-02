using System.ComponentModel.DataAnnotations;

namespace BTH_BUOI1.Models.DTO
{
    public class AddAuthorRequestDTO
    {
        [Key]
        public string? FullName { get; set; }

        public List<int> AuthorIds { get; set; }
    }
}
