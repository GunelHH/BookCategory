using System;
using HomeTaskBookCategory.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace HomeTaskBookCategory.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsBlocked { get; set; }
    }
}

