using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;
using System;
using WebApp.Data.Cais2015;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApp.Middleware;
using Microsoft.Extensions.Options;
using WebApp.Models.IdentityModels;

namespace WebApp
{
    public class Startup
    {
        private static readonly string secretKey = "mysupersecret_secretkey!123";
        private static readonly string issure = "AltairCA";
        private static readonly string audience = "AltairCAAudience";
        private static SymmetricSecurityKey signingKey;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<Cais2015Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Cais2015Connection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            services.AddMvc();

            var tokenValidationParameters = new TokenValidationParameters
            {
                //The signing key must match !
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                //Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = issure,

                //validate the JWT Audience (aud) claim

                ValidateAudience = true,
                ValidAudience = audience,

                //validate the token expiry
                ValidateLifetime = true,

                // If you  want to allow a certain amout of clock drift
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            }).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/LogOff";
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();



            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Google:ClientSecret"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.ClientId = Configuration["Facebook:ClientId"];
                    facebookOptions.ClientSecret = Configuration["Facebook:ClientSecret"];
                })
                .AddNaver(naverOptions =>
                {
                    naverOptions.ClientId = Configuration["Naver:ClientId"];
                    naverOptions.ClientSecret = Configuration["Naver:ClientSecret"];
                })
                .AddKakao(kakaoOptions =>
                {
                    kakaoOptions.ClientId = Configuration["Kakao:ClientId"];
                    kakaoOptions.ClientSecret = Configuration["Kakao:ClientSecret"];
                })
                ;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            var jwtOptions = new TokenProviderOptions
            {
                Audience = audience,
                Issuer = issure,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
            app.UseJWTTokenProviderMiddleware(Options.Create(jwtOptions));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            


        }
    }
}
