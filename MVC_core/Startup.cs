using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_core.Models;
using MVC_core.DAL;
using MVC_core.BLL;
using Microsoft.AspNetCore.Authentication.Cookies;//身份认证COOKIES
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MVC_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IRepository<UserDoNet>, UserRpo>();
            services.AddScoped<IRepository<AdministratorDoNet>, AdmRpo>();
            services.AddScoped<IServices, User>();
            services.AddScoped<Administrator>();
            //依赖注入用户类
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,o=>
                {
                    o.LoginPath = new PathString("/Account/Login");
                    o.AccessDeniedPath=new PathString("/Home/Noright");
                });
            //注册cookies认证服务

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();//认证Middleware

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Contact" }
                );       
            });
        }
    }
}
