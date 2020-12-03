using GoodWeebs.Data;
using GoodWeebs.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace goodweebs.Services.goodweebs.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(GoodWeebs.Data.ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetUserAvatarByUsername(string username)
        {
            var url = this.dbContext.Users.FirstOrDefault(x => x.UserName == username).AvatarUrl;
            return url;
        }

        public ApplicationUser GetUserByUserName(string username)
        {
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == username);
            return user;
        }
    }
}
