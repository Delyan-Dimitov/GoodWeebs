namespace GoodWeebs.Web.ViewModels.UpdateViewModels
{
    public class SeriesUpdateViewModel
    {
        public const string WatchedContentString = "{0} Finished Watching: {1}!";

        public const string WatchingContentString = "{0} Is Watching: {1}!";

        public const string WantToWatchContentString = "{0} Wants To Watch: {1}!";

        public const string ReadContentString = "{0} Finished Reading: {1}!";

        public const string ReadingContentString = "{0} Is Reading: {1}!";

        public const string WantToReadContentString = "{0} Wants To Read: {1}!";

        public string UserDisplayName { get; set; }

        public string UserId { get; set; }

        public int SeriesType { get; set; }
        
        public int UpdateId { get; set; }

        public string SeriesTitle { get; set; }

        public int SeriesId { get; set; }

        public string Content { get; set; }
    }
}
