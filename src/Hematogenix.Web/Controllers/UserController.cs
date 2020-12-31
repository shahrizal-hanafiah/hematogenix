using Hematogenix.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hematogenix.Web.Controllers
{
    public class UserController : Controller
    {
        //public IUserAppService userAppService;
        public UserController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegisterUser(RegisterViewModel registerBody)
        {

            return Json("Ok");
        }
    }
}