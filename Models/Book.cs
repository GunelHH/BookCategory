using System;
using HomeTaskBookCategory.Models.Base;

namespace HomeTaskBookCategory.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public short Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}

