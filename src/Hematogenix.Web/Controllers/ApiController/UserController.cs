using AutoMapper;
using Hematogenix.Application;
using Hematogenix.Shared.Dto;
using Hematogenix.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Models;

namespace Hematogenix.Web.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public UserDto[] Get()
        {
            try
            {
                var users = _userAppService.GetAll().ToArray();
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost("register")]
        public bool RegisterUser([FromBody]RegisterViewModel data)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<RegisterViewModel, UserDto>();
                });

                IMapper Mapper = config.CreateMapper();
                var user = Mapper.Map<RegisterViewModel, UserDto>(data);

                return _userAppService.Insert(user);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
