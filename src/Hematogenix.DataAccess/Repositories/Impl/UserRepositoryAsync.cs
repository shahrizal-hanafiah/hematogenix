using Hematogenix.Core.Model;
using Hematogenix.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.DataAccess.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["HemotagenixContext"].ConnectionString;
        public User GetUserById(int? id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var user = new User()
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Username = rdr["Username"].ToString(),
                        FirstName = rdr["FirstName"].ToString(),
                        LastName = rdr["LastName"].ToString(),
                        Role = rdr["Role"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Phone = rdr["Phone"].ToString()
                    };
                    users.Add(user);
                }
                return (users);
            }
        }

        public int Insert(UserDto user)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("spAddNew", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                return (cmd.ExecuteNonQuery());
            }
        }

        public void Update(UserDto user)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
