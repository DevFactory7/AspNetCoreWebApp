using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.IdentityModels;

namespace WebApp.Extensions
{
    public static class ControllerExtension
    {
        public static ApplicationUser GetDbUser(this Controller controller, ApplicationDbContext db)
        {
            try
            {
                string userId = controller.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).First().Value;
                ApplicationUser user = db.Users.Where(w => w.Id == userId).First();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
