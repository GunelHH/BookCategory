using System;
using System.Collections.Generic;
using HomeTaskBookCategory.Models.Base;

namespace HomeTaskBookCategory.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }

    }
}

