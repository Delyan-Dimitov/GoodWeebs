namespace GoodWeebs.Services.GoodWeebs.Services.UserServices
{
    using System.Linq;

    using global::GoodWeebs.Data;
    using global::GoodWeebs.Data.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
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
