using Hematogenix.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Application.User
{
    public class User : IUser
    {
        public IList<UserDto> GetAll(int id)
        {
            throw new NotImplementedException();
        }
        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int Insert(UserDto dto)
        {
            throw new NotImplementedException();
        }
        public void Update(UserDto dto)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
