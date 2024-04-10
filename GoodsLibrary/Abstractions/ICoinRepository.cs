using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary.Abstractions
{
    public interface ICoinRepository
    {
        public Task<Coin> Get(int id);
        public Task<List<Coin>> Get();
        public Task<int> Create(Coin coin);
        public Task<int> Update(int id, bool? available, int? count);
        public Task<int> Delete(int id);
    }
}
