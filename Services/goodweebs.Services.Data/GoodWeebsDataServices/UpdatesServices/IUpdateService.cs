namespace GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices
{
    using global::GoodWeebs.Web.ViewModels.UpdateViewModels;
    using System.Threading.Tasks;

    public interface IUpdateService
    {
        Task CreateSeriesUpdate(string userId, int seriesId, int seriesType, string contentType);

        Task CreatePostUpdate(string userId, int postId, string groupId);

        Task<UpdateListViewModel> GetRelevantUpdatesAsViewModelAsync(string userId);
    }
}
