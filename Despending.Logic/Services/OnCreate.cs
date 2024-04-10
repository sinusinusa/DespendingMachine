using DataLayer.Repositories;
using GoodsLibrary.Abstractions;
using GoodsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Despending.Logic.Services
{
    public class OnCreate : ICreate
    {
        private readonly ICoinRepository _coinRepository;
        private readonly ISecret _secret;
        public OnCreate(ICoinRepository coinRepository, ISecret secret) {
            _coinRepository = coinRepository;
            _secret = secret;
        }
        public async Task InitializeAsync()
        {
            await _coinRepository.Delete(1);
            await _coinRepository.Create(Coin.Create(1, 1, true, 50).coin);
            await _coinRepository.Delete(2);
            await _coinRepository.Create(Coin.Create(2, 2, true, 40).coin);
            await _coinRepository.Delete(3);
            await _coinRepository.Create(Coin.Create(3, 5, true, 30).coin);
            await _coinRepository.Delete(4);
            await _coinRepository.Create(Coin.Create(4, 10, true, 20).coin);
            await _secret.DeleteSecret();
            await _secret.SetSecret("mysecret");
            
        }
    }
}
