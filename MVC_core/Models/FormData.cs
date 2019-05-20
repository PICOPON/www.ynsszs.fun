
using System.ComponentModel.DataAnnotations;

namespace MVC_core.Models
{
    public class FormData
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string name { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string password { get; set; }
    }
}
