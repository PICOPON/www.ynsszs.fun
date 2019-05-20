using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_core.BLL;
using MVC_core.DAL;
using MVC_core.Models;
using System;

namespace MVC_core.Controllers
{
    [Produces("application/json")]
    [Route("Up")]
    public class UpController : Controller
    {
        private readonly IRepository<UserDoNet> userRpo;
        private readonly IRepository<AdministratorDoNet> admRpo;
        private readonly IServices services;
        private readonly Administrator administrator;
        public UpController(IRepository<UserDoNet> userRpo, IRepository<AdministratorDoNet> admRpo, IServices services, Administrator administrator)
        {
            this.userRpo = userRpo;
            this.admRpo = admRpo;
            this.services = services;
            this.administrator = administrator;
        }
        //依赖注入 BLL,DAL
        //依赖注入
        [HttpGet]
        [Route("Comment")]
        public IActionResult Comment()
        {
            return View();
        }
        //留言
        [HttpPost]
        //[Authorize]
        [Route("Comment")]
        public IActionResult Comment(string text)
        {
            try
            {
                using (MyWebDB DB = new MyWebDB())
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var comment = new CommentDoNet
                        {
                            Name = User.Identity.Name,
                            CommentText = text.Trim(),
                            Date = DateTime.Now.Date,
                            Time = DateTime.Now.TimeOfDay
                        };
                        services.AddComment(DB, admRpo, userRpo, comment);
                    }
                    else
                    {
                        var comment = new CommentDoNet
                        {
                            Name = "Unknown User",
                            CommentText = text.Trim(),
                            Date = DateTime.Now.Date,
                            Time = DateTime.Now.TimeOfDay
                        };
                        services.AddComment(DB, admRpo, userRpo, comment);
                    }
                }
                return RedirectToAction(nameof(UpController.Comment), "Up");
            }catch
            {
                return RedirectToAction(nameof(HomeController.Introduction), "Home");
            }
        }
    }
}
