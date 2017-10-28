using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.IdentityModels;

namespace WebApp.Models.RolesMgmtViewModels
{
    public class RoleViewModel
    {        
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int NumberOfUsers { get; set; }

        public RoleViewModel()
        {
        }

        public RoleViewModel(ApplicationRole role, int numberOfUsers)
        {
            this.Id = role.Id;
            RoleName = role.Name;
            Description = role.Description;
            NumberOfUsers = numberOfUsers;
        }
    }

    
}
