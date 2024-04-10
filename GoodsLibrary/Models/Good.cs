using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary.Models
{
    public class Good
    {
        private Good (Guid id, string title, Decimal price, int count, string image)
        {
            Id = id;
            Title = title;
            Price = price;
            Count = count;
            Image = image;
        }
        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public Decimal Price { get; } = new Decimal(0);

        public int Count { get; } = 0;

        public string Image { get; } = string.Empty;

        public static (Good good, string Error) Create(Guid id, string title, Decimal price, int count, string image)
        {
            var error = string.Empty;

            //Validations

            var good = new Good(id, title, price, count, image);
            return (good, error);
        }
    }
}
