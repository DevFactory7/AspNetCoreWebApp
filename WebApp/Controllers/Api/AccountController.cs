using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Extensions;
using WebApp.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApp.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var obj2 = this.GetDbUser(_dbContext);
            return Content(JsonConvert.SerializeObject(new { _data = obj2 }, Formatting.Indented), "application/json");
        }
    }
}