using DataLayer.Entities;
using GoodsLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GoodRepository : IGoodRepository
    {
       private readonly DespendingDbContext _context;
        public GoodRepository(DespendingDbContext context) {
            _context = context;
        }
        public async Task<List<Good>> Get()
        {
            var goodEntities = await _context.Goods
                .ToListAsync();
            var goods = goodEntities.Select(x => Good.Create(x.Id, x.Title, x.Price, x.Count, x.Image).good)
                .ToList();
            return goods;
        }
        public async Task<Guid> Create(Good good)
        {
            var goodEntity = new GoodEntity()
            {
                Id = good.Id,
                Title = good.Title,
                Price = good.Price,
                Image = good.Image,
                Count = good.Count,
            };
            await _context.Goods.AddAsync(goodEntity);
            await _context.SaveChangesAsync();

            return goodEntity.Id;

        }
        public async Task<Guid> Update(Guid id, string? title, decimal? price, int? count, string? image)
        {
            var goodToUpdate = await _context.Goods.FirstOrDefaultAsync(x => x.Id == id);

            if (goodToUpdate != null)
            {
                goodToUpdate.Title = title ?? goodToUpdate.Title;
                goodToUpdate.Price = price ?? goodToUpdate.Price;
                goodToUpdate.Count = count ?? goodToUpdate.Count;
                goodToUpdate.Image = image ?? goodToUpdate.Image;

                _context.Goods.Update(goodToUpdate);
            }

            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            var entity = _context.Goods
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (entity != null)
            {
                _context.Goods.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<Good> GetOne(Guid id)
        {
            var result =  await _context.Goods.FirstOrDefaultAsync(x => x.Id == id);
            return Good.Create(result.Id, result.Title, result.Price, result.Count, result.Image).good;
        }
    }
}
