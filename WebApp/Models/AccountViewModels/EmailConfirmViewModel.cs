using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.AccountViewModels
{
    /// <summary>
    /// EmailConfirmViewModel
    /// </summary>
    public class EmailConfirmViewModel
    {
        [EmailAddress]
        [Display(Name = "이메일주소")]
        public string Email { get; set; }

        public string Id { get; set; }
        public bool IsEmailChanging { get; set; }
    }
}
