using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kuna.Model
{
    public interface IUserRepository
    {
        bool AutenticateUser(NetworkCredential credential);//Contraseña tipo segura 
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetByID(int id);
        UserModel GetByUserName(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
