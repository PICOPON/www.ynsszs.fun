using Microsoft.AspNetCore.Mvc;
using MVC_core.BLL;
using MVC_core.DAL;
using MVC_core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;

namespace MVC_core.Controllers
{
    [Produces("application/json")]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IRepository<UserDoNet> userRpo;
        private readonly IRepository<AdministratorDoNet> admRpo;
        private readonly IServices services;
        private readonly Administrator administrator;
        public AccountController(IRepository<UserDoNet> userRpo, IRepository<AdministratorDoNet> admRpo, IServices services, Administrator administrator)
        {
            this.userRpo = userRpo;
            this.admRpo = admRpo;
            this.services = services;
            this.administrator = administrator;
        }
        //依赖注入 BLL,DAL
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        //注册
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
   
       //登录
       [HttpPost]
       [Route("Register")]
       public IActionResult Register(FormData formData)
       {
           if(formData.name==null||formData.password==null)
           {
               ViewData["Message"] = "注册信息不能为空！";
               return View(nameof(HomeController.Message), "Account");
           }
           using (MyWebDB DB = new MyWebDB())
           {
               if(services.Register(DB,admRpo,userRpo,formData))
               {
                   ViewData["Message"] = "注册成功！";
                   return View(nameof(HomeController.Message),"Account");
               }
               else
               {
                   ViewData["Message"] = "注册失败！用户名已存在";
                   return View(nameof(HomeController.Message), "Account");
               }
           }    
       }
       //注册
       [HttpPost]
       [Route("Login")]
       public async Task<IActionResult> Login(FormData formData)
       {
           if (formData.name == null || formData.password == null)
           {
               ViewData["Message"] = "登陆信息不能为空！";
               return View(nameof(HomeController.Message), "Account");
           }
           else
           {
               using (MyWebDB DB = new MyWebDB())
               {
                    if ((int)services.Login(DB, admRpo, userRpo, formData) == 0)
                   {
                       var ClaimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                       ClaimsIdentity.AddClaim(new Claim(ClaimTypes.Name, formData.name));
                       ClaimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                       ClaimsPrincipal user = new ClaimsPrincipal(ClaimsIdentity);
                       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                           user, new AuthenticationProperties()
                           {
                               IsPersistent = true,
                               ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                               AllowRefresh = true
                           });
                       return RedirectToAction(nameof(AccountController.UserController), "Account");
                   }else if((int)services.Login(DB, admRpo, userRpo, formData) == 1)
                   {
                       var ClaimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                       ClaimsIdentity.AddClaim(new Claim(ClaimTypes.Name, formData.name));
                       ClaimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
                       ClaimsPrincipal user = new ClaimsPrincipal(ClaimsIdentity);
                       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                           user, new AuthenticationProperties()
                           {
                               IsPersistent = true,
                               ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                               AllowRefresh = true
                           });
                       return RedirectToAction(nameof(AccountController.AdministratorController), "Account");
                   }
                   else 
                   {
                       ViewData["Message"] = "登陆失败！该用户不存在！";
                       return View(nameof(HomeController.Message), "Account");
                   }
               }
           }
       }
       //注册
       [HttpGet]
       [Route("LogOut")]
       public async Task<IActionResult> LogOut()
       {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           return RedirectToAction(nameof(HomeController.Translation), "Home");
       }
       //退出登录
       [HttpGet]
       [Authorize(Roles = "User")]
       [Route("UserController")]
       public IActionResult UserController()
       {

           return View();
       }
       //用户控制台
       [HttpGet]
       [Authorize(Roles = "Administrator")]
       [Route("AdministratorController")]
       public IActionResult AdministratorController()
       {
           return View();
       }
      //管理员控制台
    }
}