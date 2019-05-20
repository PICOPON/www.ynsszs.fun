using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_core.Models
{
    public class AdministratorDoNet
    {
        [Key]
        public int Id { get; set; }
        public string AdministratorName { get; set; }
        public string Password { get; set; }
        
        public Boolean IsUser { get; set; }
    }
}
