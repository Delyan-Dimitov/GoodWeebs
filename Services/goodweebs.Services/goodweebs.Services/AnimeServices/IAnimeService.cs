using Entities;
using GoodWeebs.Data.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodWeebs.Services
{
    public interface IAnimeService
    {
        Task<IEnumerable<Anime>> GetAllAsync();

        Task<IEnumerable<Anime>> GetTopGlobalAsync(int amount);

    }
}
