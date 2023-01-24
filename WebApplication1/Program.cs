using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //MVC injection a DatabaseContext i ekle diyoruz.
            builder.Services.AddDbContext<DatabaseContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                //proxies property leri eklemek istersek; opts.UseLazyLoadingProxies();
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = ".WebApplication1.auth";
                    opts.ExpireTimeSpan = TimeSpan.FromDays(7); //veri kaç gün sonra silinsin
                    opts.SlidingExpiration = false; //giriş yapıldıkça 7 günlük süre uzatılmasın
                    opts.LoginPath = "/Account/Login";
                    opts.LogoutPath= "/Account/Logout";
                    opts.AccessDeniedPath = "/Home/AccessDenied";

                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//kimlik doğrulama

            app.UseAuthorization();//rolleri kontrol et

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}