using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class GoodEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Decimal Price { get; set; } = new Decimal(0);

        public int Count { get; set; } = 0;

        public string Image { get; set; } = string.Empty;
    }
}
