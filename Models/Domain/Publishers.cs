using BTH_BUOI1.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BTH_BUOI1.Models
{
    public class Publishers
    {
        [Key]
        public int? ID { get; set; }
        public string? Name { get; set; }

        public List<Books>? Books { get; set; }
    }
}
