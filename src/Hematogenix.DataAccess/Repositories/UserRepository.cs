using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hematogenix.DataAccess.Extensions;
using Hematogenix.Core.Model;

namespace Hematogenix.DataAccess.Repositories
{
    public class UserRepository : Repository<User>
    {
        private DbContext _context;
        public UserRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }


        public IList<User> GetUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[spGetUsers]";

                return this.ToList(command).ToList();
            }
        }

        public bool CreateUser(User user)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spCreateUser";

                command.Parameters.Add(command.CreateParameter("@UserName", user.Username));
                command.Parameters.Add(command.CreateParameter("@FirstName",user.FirstName));
                command.Parameters.Add(command.CreateParameter("@LastName", user.LastName));
                command.Parameters.Add(command.CreateParameter("@Role", user.Role));
                command.Parameters.Add(command.CreateParameter("@Email", user.Email));
                command.Parameters.Add(command.CreateParameter("@Phone", user.Phone));

                return (ToList(command).FirstOrDefault()!=null);              
            }
           
        }

        public User GetUserByUsernameOrEmail(string username,string email)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetUserByUsernameOrEmail";

                command.Parameters.Add(command.CreateParameter("@Username", username));
                command.Parameters.Add(command.CreateParameter("@Email", email));

                return this.ToList(command).FirstOrDefault();
            }
        }

        
    }
}
