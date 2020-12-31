using Hematogenix.Core.Model;
using Hematogenix.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.DataAccess.Repositories
{
    public interface IUserRepository 
    {
        IList<User> GetUsers();
        User GetUserById(int? id);
        int Insert(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
    }
}
