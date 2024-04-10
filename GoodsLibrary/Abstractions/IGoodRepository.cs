using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IGoodRepository
    {
        public Task<Good> GetOne(Guid id);
        public Task<List<Good>> Get();
        public Task<Guid> Create(Good good);
        public Task<Guid> Update(Guid id, string? title, decimal? price, int? count, string? image);
        public Task<Guid> Delete(Guid id);
    }
}
