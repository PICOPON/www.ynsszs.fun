using MVC_core.DAL;
using MVC_core.Models;
namespace MVC_core.BLL
{
    public interface IServices
    {
        Identity Login(MyWebDB dB, IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, FormData formData);
        bool Register(MyWebDB dB, IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, FormData formData);
        bool AddComment(MyWebDB dB, IRepository<AdministratorDoNet> admRpo, IRepository<UserDoNet> userRpo, CommentDoNet commentDoNet);

    }

}
