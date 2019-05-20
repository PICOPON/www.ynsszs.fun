using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_core.DAL;
using MVC_core.Models;


namespace MVC_core.BLL
{
    public enum Identity { user, administrator, none }
    public class User : IServices
    {
        public Identity Login(MyWebDB dB,IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, FormData formData)
        {
            try
            {
                if(userRpo.CheckUser(dB, formData))
                {
                    return Identity.user;
                }else if(admRpo.CheckUser(dB,formData))
                {
                    return Identity.administrator;
                }else
                {
                    return Identity.none;
                }
            }catch
            {
                return Identity.none;
            }
        }

        public bool Register(MyWebDB dB, IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, FormData formData)
        {
            try
            {
                if (userRpo.CheckUserByName(dB,formData.name))
                {
                    return false;
                }
                else
                {
                    userRpo.AddUser(dB, formData);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool AddComment(MyWebDB dB, IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, CommentDoNet commentDoNet)
        {
            try
            {
                userRpo.AddCommentDoNet(dB, commentDoNet);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
