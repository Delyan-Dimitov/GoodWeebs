namespace GoodWeebs.Services.GoodWeebs.Services.UserServices
{
    using global::GoodWeebs.Data.Models;

    public interface IUserService
    {
        string GetUserAvatarByUsername(string username);

        ApplicationUser GetUserByUserName(string username);
    }
}
