using GoodWeebs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace goodweebs.Services.goodweebs.Services.UserServices
{
    public interface IUserService
    {
        string GetUserAvatarByUsername(string username);

        ApplicationUser GetUserByUserName(string username);
    }
}
