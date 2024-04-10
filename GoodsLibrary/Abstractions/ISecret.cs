using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary.Abstractions
{
    public interface ISecret
    {
        public Task<bool> SetSecret(string secret);
        public Task<bool> DeleteSecret();

        public Task<bool> Check(string secret);
    }
}
