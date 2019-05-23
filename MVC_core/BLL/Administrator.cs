using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_core.DAL;
using MVC_core.Models;

namespace MVC_core.BLL
{
    public class Administrator :User
    {
        public bool UpLoadFile()
        {
            return true;
        }
    }
}
