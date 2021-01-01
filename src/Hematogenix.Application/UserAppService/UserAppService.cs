using AutoMapper;
using Hematogenix.Application.Helper;
using Hematogenix.Core.Model;
using Hematogenix.DataAccess;
using Hematogenix.DataAccess.Repositories;
using Hematogenix.Shared.Dto;
using Hematogenix.Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Application.UserAppService
{
    public class UserAppService : IUserAppService
    {
        //private readonly IUserRepository _userRepository;
        //private IConnectionFactory _connectionFactory = ;
        private DbContext _context = new DbContext(ConnectionHelper.GetConnection());

        public UserAppService()
        {
        }
        public IList<UserDto> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            IMapper Mapper = config.CreateMapper();

            var userRepository = new UserRepository(_context);

            var users = userRepository.GetUsers();

            return (Mapper.Map<IList<User>, IList<UserDto>>(users));
        }
        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }
        public bool Insert(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException("User is empty");

            if (string.IsNullOrEmpty(userDto.Username))
                throw new ArgumentNullException("Username is required");

            if (userDto.Username.Length > 50)
                throw new ArgumentOutOfRangeException("Username exceed 50 character");

            if(string.IsNullOrEmpty(userDto.FirstName))
                throw new ArgumentNullException("First name is required");

            if (userDto.FirstName.Length > 50)
                throw new ArgumentOutOfRangeException("First name exceed 50 character");

            if (string.IsNullOrEmpty(userDto.LastName))
                throw new ArgumentNullException("Last name is required");

            if (userDto.LastName.Length > 50)
                throw new ArgumentOutOfRangeException("Last name exceed 50 character");

            if (string.IsNullOrEmpty(userDto.Role))
                throw new ArgumentNullException("Role is required");

            if(string.IsNullOrEmpty(userDto.Email))
                throw new ArgumentNullException("Email is required");

            if(!Email.IsValidEmail(userDto.Email))
                throw new FormatException("Incorrect email format");

            if(userDto.Role == "superuser" && string.IsNullOrEmpty(userDto.Phone))
                throw new ArgumentNullException("Phone is required");


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto,User>();
            });

            IMapper Mapper = config.CreateMapper();

            var user = Mapper.Map<UserDto, User>(userDto);

            var userRepository = new UserRepository(_context);

            return(userRepository.CreateUser(user));
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
