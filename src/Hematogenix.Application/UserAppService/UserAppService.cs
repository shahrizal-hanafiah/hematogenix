using AutoMapper;
using Hematogenix.Core.Model;
using Hematogenix.DataAccess.Repositories;
using Hematogenix.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Application.UserAppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<UserDto> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            IMapper Mapper = config.CreateMapper();

            var users = _userRepository.GetUsers();

            return (Mapper.Map<IList<User>, IList<UserDto>>(users));
        }
        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int Insert(UserDto userDto)
        {
            return (_userRepository.Insert(userDto));
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
