using DataLayer.Repositories;
using Despending.Logic.Abstractions;
using Despending.Logic.Models;
using GoodsLibrary.Abstractions;
using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Despending.Logic.Services
{
    public class DespendingService : IDespendingService
    {
        private readonly IGoodRepository _goodRepository;
        private readonly ICoinRepository _coinRepository;
        private readonly ISecret _secret;
        public DespendingService(IGoodRepository goodRepository, ICoinRepository coinRepository, ISecret secret)
        {
            _goodRepository = goodRepository;
            _coinRepository = coinRepository;
            _secret = secret;
        }
        #region funcs
        #endregion
        #region userActivity
        public async Task<bool> Despend(List<PickCoin> pickCoins, Guid id)
        {
            var good = await GetGood(id);
            var coins = await GetAllCoins();
            if(good.Count > 0)
            {
                
                foreach (var coin in pickCoins)
                {
                    if (coin.Coin == null)
                    {
                        coin.Coin = coins.First(x => x.Id == coin.Id);
                        if (!coin.Coin.Available) return false;
                    }
                    // Add coins to machine
                             
                }
                var sum = (decimal)pickCoins.Sum(x => x.Count * x.Coin.Nominal);
                if (good.Price <= sum)
                {
                    foreach (var coin in pickCoins)
                    {
                        if (!(await AddCoin(coin.Id, coin.Count))) return false;
                    }

                    //Update Datas
                    coins = await GetAllCoins();
                    
                    //Despend one good
                    await UpdateGood(id, null, null, good.Count - 1, null);
                    var change = (int)(sum - good.Price);
                    var availableCoins = coins.Where(c => c.Count > 0)
                        .OrderByDescending(c => c.Nominal).ToList();
                    foreach (var coin in availableCoins)
                    {
                        while (change >= coin.Nominal && coin.Count > 0)
                        {
                            change -= coin.Nominal;
                            await AddCoin(coin.Id, -1);
                        }
                    }
                    return true;
                }
                
            }
            return false;
        }
        #endregion
        #region secret
        public async Task<bool> Validate(string secret)
        {
            return await _secret.Check(secret);
        }
        #endregion
        #region CoinActions
        public async Task<bool> AddCoin(int id, int count)
        {
            var coin = await GetCoin(id);
            if (coin.Available) {
                if (count < 0)
                {
                    if (coin.Count < -count) return false;
                    if (coin.Count == -count)
                    {
                        await UpdateCoin(coin.Id, null, 0);
                        return true;
                    }
                    if (coin.Count > -count)
                    {
                        await UpdateCoin(coin.Id, null, coin.Count + count);
                        return true;
                    }
                }
                if (count > 0)
                {
                    await UpdateCoin(coin.Id, null, coin.Count + count);
                    return true;
                }
              }
            return false;
        }
        public async Task<Coin> GetCoin(int id)
        {
            return await _coinRepository.Get(id);
        }
        public async Task<List<Coin>> GetAllCoins()
        {
            return await _coinRepository.Get();
        }
        public async Task<int> UpdateCoin(int id, bool? available, int? count)
        {
            bool canUpdate = true;
            
            if (count < 0) { canUpdate = false; }
            if (count == 0) { available = false; }
            
            if(canUpdate)
            {
                await _coinRepository.Update(id, available, count);
                return id;
            }
            return 0;
        }
        #endregion
        #region GoodActions
        public async Task<Good> GetGood(Guid id)
        {
            return await _goodRepository.GetOne(id);
        }
        public async Task<List<Good>> GetAllGoods()
        {
            return await _goodRepository.Get();
        }
        public async Task<Guid> CreateGood(Good good)
        {
            return await _goodRepository.Create(good);
        }
        public async Task<Guid> UpdateGood(Guid id, string? title, decimal? price, int? count, string? image)
        {
            return await _goodRepository.Update(id, title, price, count, image);
        }
        public async Task<Guid> DeleteGood(Guid id)
        {
            return await _goodRepository.Delete(id);
        }
        #endregion
    }
}
