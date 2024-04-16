using BTH_BUOI1.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BTH_BUOI1.Models
{
    public class Book_Author
    {
        [Key]
        public int? ID { get; set; }

        public int? BookId { get; set; } 
        public int? AuthorId { get; set; } 

        public Books? Book { get; set; } 
        public Authors? Author { get; set; } 
    }
}

