using DataLayer.Repositories;
using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Despending.Logic.Models;

namespace Despending.Logic.Abstractions
{
    public interface IDespendingService
    {
        public Task<bool> Despend(List<PickCoin> pickCoins, Guid id);
        public Task<Coin> GetCoin(int id);
        public Task<List<Coin>> GetAllCoins();
        public Task<int> UpdateCoin(int id, bool? available, int? count);
        public Task<List<Good>> GetAllGoods();
        public Task<Guid> CreateGood(Good good);
        public Task<Guid> UpdateGood(Guid id, string? title, decimal? price, int? count, string? image);
        public Task<Guid> DeleteGood(Guid id);
    }
}
