using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.IdentityModels;

namespace WebApp.Models.RolesMgmtViewModels
{
    public class RoleAddEditViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }

        public RoleAddEditViewModel()
        {
        }

        public RoleAddEditViewModel(IdentityRole applicationRole)
        {
            Id = applicationRole.Id;
            RoleName = applicationRole.Name;
        }
    }
}
