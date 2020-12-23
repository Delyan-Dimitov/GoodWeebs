using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices
{
    public interface IUpdateService
    {
        Task CreateSeriesUpdate(string userId, int seriesId, int seriesType, string contentType);
    }
}
