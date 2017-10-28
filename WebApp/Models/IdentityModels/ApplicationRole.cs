using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole
    {
        [StringLength(250)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string IPAddress { get; set; }
    }
}
