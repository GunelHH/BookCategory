using System;
using FluentValidation;

namespace HomeTaskBookCategory.DTOs.Category
{
    public class CategoryGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}

