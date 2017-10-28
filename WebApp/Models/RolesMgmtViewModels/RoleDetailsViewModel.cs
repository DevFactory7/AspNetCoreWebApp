using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.IdentityModels;

namespace WebApp.Models.RolesMgmtViewModels
{
    public class RoleDetailsViewModel
    {
        public IdentityRole Role { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public RoleDetailsViewModel()
        {

        }
    }
}
