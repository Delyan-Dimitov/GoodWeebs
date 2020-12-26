namespace GoodWeebs.Services.Data.GoodWeebsDataServices.GroupServices
{
    using System.Threading.Tasks;

    using global::GoodWeebs.Web.ViewModels.GroupViewModel;

    public interface IGroupService
    {
        Task CreateGroupAsync(CreateGroupInputModel model, string userId);

        Task<GroupListViewModel> GetUsersGroupsAsync(string userId);

        Task<GroupViewModel> GetGroupByIdAsync(string groupId);

        Task CreatePostAsync(CreatePostInputModel model, string submitterId);

        Task CreateCommentAsync(CommentInputModel model, string commenterId, string postId);

        Task <PostViewModel> GetPostByIdAsync(string postId);

        Task AddUserToGroup(string userId, string groupId);
    }
}
