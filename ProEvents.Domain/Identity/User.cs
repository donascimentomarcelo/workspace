using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProEvents.Domain.Enum;

namespace ProEvents.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TitleEnum Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}