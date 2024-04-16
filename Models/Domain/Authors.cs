﻿using System.ComponentModel.DataAnnotations;

namespace BTH_BUOI1.Models
{
    public class Authors
    {
        [Key]
        public int? ID { get; set; }
        public string? FullName { get; set; }

        public List<Book_Author>? Book_Authors { get; set; }
    }
}
