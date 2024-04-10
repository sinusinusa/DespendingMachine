using DataLayer.Entities;
using GoodsLibrary.Abstractions;
using GoodsLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class SecretRepository : ISecret
    {
        private readonly DespendingDbContext _context;
        public SecretRepository(DespendingDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteSecret()
        {
            var keys = await _context.Secret.ToListAsync();

            keys.ForEach( key =>  _context.Remove(key));
            
            return true;      
        }

        public async Task<bool> SetSecret(string secret)
        {
            var delete = await DeleteSecret();
            if (delete) _context.Secret.Add(new MachineEntity() { Secret = secret });
            var success = _context.SaveChanges();
            if(success == 1) return true;
            return false;
        }
        public async Task<bool> Check(string secret)
        {
            var count = await _context.Secret.Select(x => x.Secret.ToLower() == secret.ToLower()).ToListAsync();

            if(count.Count == 1) return true;
            else return false;
        }
    }
}
