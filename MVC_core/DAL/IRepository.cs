using MVC_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_core.DAL
{
    public interface IRepository<T> where T : class
    {
        bool AddUser(MyWebDB myWebDB, FormData formData);//C
        Task<bool> DeleteUser(MyWebDB myWebDB, FormData formData);//D
        Task<bool> EditUser(MyWebDB myWebDB, FormData formData);//U
        bool CheckUser(MyWebDB myWebDB, FormData formData);//R
        bool CheckUserByName(MyWebDB myWebDB, string name);
        List<T> GetAllUser(MyWebDB myWebDB);//列出所有
        bool AddCommentDoNet(MyWebDB myWebDB,CommentDoNet commentDoNet); 
    }
}
