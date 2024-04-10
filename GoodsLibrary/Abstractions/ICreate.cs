using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary.Abstractions
{
    public interface ICreate
    {
        public Task InitializeAsync();
    }
}
