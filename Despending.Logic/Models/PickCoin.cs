using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despending.Logic.Models
{
    public class PickCoin
    {
        public int Id { get; set; }
        public Coin? Coin { get; set; }
        public int Count { get; set; }
      
    }
}
