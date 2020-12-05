using GoodWeebs.Services.GoodWeebs.Services.UserServices;
using GoodWeebs.Web.ViewModels.UserViewModels;
using GoodWeebs.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodWeebs.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Profile(string userName)
        {
            var model = new ProfileViewModel();

            var user = this.userService.GetUserByUserName(userName);
            model.AvatarUrl = user.AvatarUrl;
            model.Id = user.Id;
            return this.View(model);
        }
    }
}
