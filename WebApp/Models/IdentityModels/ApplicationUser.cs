using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.IdentityModels
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20)]
        [Required]
        public string NickName { get; set; }
    }
}
