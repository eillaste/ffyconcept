using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppRole: IdentityRole<Guid>
    {
//        [StringLength(128, MinimumLength  = 1)]
//        public string DisplayName { get; set; } = default!;
        //public string? AccountType { get; set; }
        //public virtual ICollection<AppUser>? AppUsers { get; set; }
    }
}