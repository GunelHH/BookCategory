using System;
namespace HomeTaskBookCategory.DTOs
{
    public class ListDto<T>
    {
        public ListDto<T> ListItemDto { get; set; }

        public int TotalCount { get; set; }
    }
}


