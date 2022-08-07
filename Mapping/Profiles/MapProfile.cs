using System;
using AutoMapper;
using HomeTaskBookCategory.DTOs.Book;
using HomeTaskBookCategory.Models;

namespace HomeTaskBookCategory.Mapping.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookGetDto>();
        }
    }
}

