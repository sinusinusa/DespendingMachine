using DataLayer.Entities;
using GoodsLibrary.Abstractions;
using GoodsLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private readonly DespendingDbContext _context;
        public CoinRepository(DespendingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Coin coin)
        {
            var coinEntity = new CoinEntity()
            {
                Id = coin.Id,
                Nominal = coin.Nominal,
                Available = coin.Available,
                Count = coin.Count,
            };
            await _context.Coins.AddAsync(coinEntity);
            await _context.SaveChangesAsync();

            return coinEntity.Id;
        }

        public async Task<int> Delete(int id)
        {
            var entity = _context.Coins
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (entity != null)
            {
                _context.Coins.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<List<Coin>> Get()
        {
            var coinEntities = await _context.Coins
                .ToListAsync();
            var coins = coinEntities.Select(x => Coin.Create(x.Id, x.Nominal, x.Available, x.Count).coin)
                .ToList();
            return coins;
        }

        public async Task<Coin> Get(int id)
        {
            var coinEntity = await _context.Coins
                .FirstOrDefaultAsync(x => x.Id == id);
            var coin = Coin.Create(coinEntity.Id, coinEntity.Nominal, coinEntity.Available, coinEntity.Count);
            return coin.coin;
        }

        public async Task<int> Update(int id, bool? available, int? count)
        {
            var coinToUpdate = await _context.Coins.FirstOrDefaultAsync(x => x.Id == id);
            if (coinToUpdate != null)
            {
                coinToUpdate.Available = available ?? coinToUpdate.Available;
                coinToUpdate.Count = count ?? coinToUpdate.Count;

                _context.Coins.Update(coinToUpdate);

            }
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
