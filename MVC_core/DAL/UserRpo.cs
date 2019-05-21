using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_core.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_core.DAL
{
    public class UserRpo : IRepository<UserDoNet>
    {
        public bool AddUser(MyWebDB myWebDB, FormData formData)
        {
            try
            {
                var userDoNet = new UserDoNet
                {
                    UserName = formData.name,
                    Password = formData.password,
                    IsUser = true
                };
                myWebDB.User.Add(userDoNet);
                myWebDB.SaveChanges();
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
                var expr = from item in myWebDB.User
                           where item.UserName == formData.name
                           select item;
                var UserEntity = expr.SingleOrDefault();
                if (UserEntity == null)
                {
                    return false;
                }else
                {
                    myWebDB.Set<UserDoNet>().Remove(UserEntity);
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
                var expr = from item in myWebDB.User
                           where item.UserName == formData.name
                           select item;
                var UserEntity = expr.SingleOrDefault();
                if (UserEntity == null)
                {
                    return false;
                }
                UserEntity.UserName = formData.name;
                UserEntity.Password = formData.password;
                myWebDB.Set<UserDoNet>().Update(UserEntity);
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
            var queryResult = from item in myWebDB.User
                              select new { name = item.UserName, password = item.Password };
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
       
        public List<UserDoNet> GetAllUser(MyWebDB myWebDB)
        {
            return myWebDB.User.ToList<UserDoNet>();
        }

        public bool CheckUserByName(MyWebDB myWebDB, string name)
        {
            int result = 0;
            var queryResult = from item in myWebDB.User
                              select new { name = item.UserName};
            foreach (var i in queryResult)
            {
                if (i.name.Trim() == name)
                {
                    result++;
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
            return myWebDB.Comment.ToList<CommentDoNet>();
        }
        //添加评论

    }

}
