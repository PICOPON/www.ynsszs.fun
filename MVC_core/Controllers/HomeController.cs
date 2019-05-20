using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_core.DAL;
using MVC_core.Models;
using MVC_core.BLL;
using Microsoft.AspNetCore.Authorization;

namespace MVC_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<UserDoNet> userRpo;
        private readonly IRepository<AdministratorDoNet> admRpo;
        private readonly IServices services;
        private readonly Administrator administrator;
        public HomeController(IRepository<UserDoNet> userRpo, IRepository<AdministratorDoNet> admRpo, IServices services, Administrator administrator)
        {
            this.userRpo = userRpo;
            this.admRpo = admRpo;
            this.services = services;
            this.administrator = administrator;
        }
        //依赖注入 BLL,DAL
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //首页
        [HttpGet]
        public IActionResult Introduction()
        {
            List<IdentityInfo> identityInfos = new List<IdentityInfo>();
            using (MyWebDB DB = new MyWebDB())
            {
                foreach (var adm in admRpo.GetAllUser(DB))
                {
                    identityInfos.Add(new IdentityInfo { name = adm.AdministratorName, IsUser = false });
                }
                foreach (var user in userRpo.GetAllUser(DB))
                {
                    identityInfos.Add(new IdentityInfo { name = user.UserName, IsUser = true });
                }
            }
            return View(identityInfos);
        }
        //关于我们
      
        [HttpGet]
        public IActionResult Picture()
        {
            return View();
        }
       //图片
       [HttpGet]
       [Authorize]
        public IActionResult Translation()
        {
            return View();
        }
        //翻译
        [HttpGet]
        public IActionResult Contact()
        {

            return View();
        }
        //联系我们
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
        //关于我们
        [HttpGet]
        [Route("Message")]
        public IActionResult Message()
        {
            return View();
        }
        //回馈信息
        public IActionResult Noright()
        {
            return View();
        }
        //无权查看
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //错误页
    }
}
