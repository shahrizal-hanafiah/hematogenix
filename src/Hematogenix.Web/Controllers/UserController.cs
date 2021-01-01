using AutoMapper;
using Hematogenix.Application;
using Hematogenix.Shared.Dto;
using Hematogenix.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [ActionName("GetUsers")]
        public JsonResult GetUsers()
        {
            var status = new RequestStatusViewModel()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Something went wrong during get the user list."
            };

            try
            {
                var users = _userAppService.GetAll().ToArray();
                return Json(users);
            }
            catch (Exception ex)
            {
                status.Description = ex.Message;
                return Json(status);
            }
        }

        [HttpPost]
        public JsonResult RegisterUser(RegisterViewModel data)
        {
            var status = new RequestStatusViewModel()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Register failed!"
            };

            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<RegisterViewModel, UserDto>();
                });

                IMapper Mapper = config.CreateMapper();
                var user = Mapper.Map<RegisterViewModel, UserDto>(data);

                if (_userAppService.Insert(user))
                {
                    status.StatusCode = HttpStatusCode.OK;
                    status.Message = "Successfully register the user";
                }                 
            }
            catch (Exception ex)
            {
                status.Message = ex.Message;
            }

            return Json(status);
        }
    }
}
