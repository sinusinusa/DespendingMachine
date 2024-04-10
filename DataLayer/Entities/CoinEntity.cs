using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class CoinEntity
    {
        public int Id { get; set; }
        public int Nominal { get; set; } = 1;
        public bool Available { get; set; } = true;

        public int Count { get; set; } = 1;

    }
}
