using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary.Models
{
    public class Coin
    {
        private Coin(int id, int nominal, bool available, int count)
        {
            Id = id;
            Nominal = nominal;
            Available = available;
            Count = count;
        }

        public int Id { get;}
        public int Nominal { get; } = 1;
        public bool Available { get; } = true;

        public int Count { get; } = 1;

        public static (string error, Coin coin) Create(int id, int nominal, bool available, int count)
        {       
            var error = string.Empty;

            //Validations

            var coin = new Coin(id, nominal, available, count);

            return(error, coin);
        }
    }
}
