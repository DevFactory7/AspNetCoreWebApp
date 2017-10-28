using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApp.Models.RolesMgmtViewModels;
using WebApp.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationRoleController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ApplicationDbContext context;

        public ApplicationRoleController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<RoleViewModel> model = new List<RoleViewModel>();
            model = roleManager.Roles.Select(r => new RoleViewModel(r, context.UserRoles.Where(w => w.RoleId.Equals(r.Id)).Count())).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName,Description")] RoleAddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole
                {
                    CreatedDate = DateTime.Now,
                    Name = model.RoleName,
                    Description = model.Description,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };

                var roleResult = await roleManager.CreateAsync(applicationRole);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var item = await roleManager.FindByIdAsync(id);
                return View(new RoleAddEditViewModel(item));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,RoleName,Description")] RoleAddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationRole = await roleManager.FindByIdAsync(model.Id);
                applicationRole.Name = model.RoleName;
                //applicationRole.Description = model.Description;
                IdentityResult roleResult = await roleManager.UpdateAsync(applicationRole);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new NotFoundResult();
            }

            var role = await roleManager.FindByIdAsync(id);
            var userRoles = await context.UserRoles.Where(w => w.RoleId.Equals(id)).Select(s=>s.UserId).ToListAsync();
            var users = await userManager.Users.Where(w => userRoles.Contains(w.Id)).ToListAsync();
            var roleDetailsViewModel = new RoleDetailsViewModel
            {
                Role = role,
                Users = users
            };

            return View(roleDetailsViewModel);
        }
    }
}