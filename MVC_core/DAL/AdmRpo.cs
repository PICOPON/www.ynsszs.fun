using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_core.Models;

namespace MVC_core.DAL
{
    public class AdmRpo : IRepository<AdministratorDoNet>
    {
        public bool AddUser(MyWebDB myWebDB, FormData formData)
        {
            try
            {
                var AdmDoNet = new AdministratorDoNet
                {
                    AdministratorName=formData.name,
                    Password=formData.password,
                    IsUser = false
                };
                myWebDB.Administrator.Add(AdmDoNet);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //增
        public async Task<bool> DeleteUser(MyWebDB myWebDB, FormData formData)
        {
            try
            {
                var expr = from item in myWebDB.Administrator
                           where item.AdministratorName == formData.name
                           select item;
                var AdmEntity = expr.SingleOrDefault();
                if (AdmEntity == null)
                {
                    return false;
                }
                else
                {
  
                    myWebDB.Set<AdministratorDoNet>().Remove(AdmEntity);
                    return await myWebDB.SaveChangesAsync() > 0;
                }
            }
            catch
            {
                return false;
            }

        }
        //删
        public async Task<bool> EditUser(MyWebDB myWebDB, FormData formData)
        {
            try
            {
                var expr = from item in myWebDB.Administrator
                           where item.AdministratorName == formData.name
                           select item;
                var AdmEntity = expr.SingleOrDefault();
                if (AdmEntity == null)
                {
                    return false;
                }
                AdmEntity.AdministratorName = formData.name;
                AdmEntity.Password = formData.password;
                myWebDB.Set<AdministratorDoNet>().Update(AdmEntity);
                return await myWebDB.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;

            }
        }
        //改
        public bool CheckUser(MyWebDB myWebDB, FormData formData)
        {
            int result = 0;
            var queryResult = from item in myWebDB.Administrator
                              select new { name = item.AdministratorName, password = item.Password };
            foreach (var i in queryResult)
            {
                if (i.name.Trim() == formData.name)
                {
                    if (i.password.Trim() == formData.password)
                    {
                        result++;
                    }
                }
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         //查
        public List<AdministratorDoNet> GetAllUser(MyWebDB myWebDB)
        {
            return myWebDB.Administrator.ToList<AdministratorDoNet>();
        }

        public bool CheckUserByName(MyWebDB myWebDB, string name)
        {
            throw new NotImplementedException();
        }

        public bool AddCommentDoNet(MyWebDB myWebDB,CommentDoNet commentDoNet)
        {
            try
            {
                myWebDB.Comment.Add(commentDoNet);
                myWebDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CommentDoNet> ShowAllComment(MyWebDB myWebDB)
        {
            throw new NotImplementedException();
        }
        //添加评论
    }
}
