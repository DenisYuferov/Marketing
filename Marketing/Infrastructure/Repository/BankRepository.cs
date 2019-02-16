using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Marketing.Models;
using Marketing.Data;
using Marketing.Infrastructure.Repository.Interfaces;

namespace Marketing.Infrastructure.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly MarketingDbContext _marketingDbContext;

        public BankRepository(MarketingDbContext marketingDbContext)
        {
            _marketingDbContext = marketingDbContext;

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            var isThereBanks = await _marketingDbContext.Banks.AnyAsync();

            if (isThereBanks) return;

            for (int i = 100000001; i <= 100002000; i++)
            {
                var app = new Bank { Bic = i.ToString(), Name = $"Банк {i - 100000000}", RecordDate = DateTime.Now};

                await _marketingDbContext.AddAsync(app);
            }

            await _marketingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bank>> AllAsync()
        {
            return await _marketingDbContext.Banks.OrderByDescending(b => b.RecordDate).Take(20).ToListAsync();
        }

        public async Task<Bank> GetByBicAsync(string bic)
        {
            return await _marketingDbContext.Banks.FirstOrDefaultAsync(b => b.Bic == bic);
        }

        public async Task UpsertAsync(Bank bank)
        {
            var existBank = await GetByBicAsync(bank.Bic);

            if (existBank == null)
            {
                await _marketingDbContext.Banks.AddAsync(bank);
            }
            else
            {
                existBank.Name = bank.Name;
                existBank.RecordDate = bank.RecordDate;
            }
            
            await _marketingDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string bic)
        {
            var existBank = await GetByBicAsync(bic);

            if (existBank == null) return;
            
            _marketingDbContext.Banks.Remove(existBank);

            await _marketingDbContext.SaveChangesAsync();
        }
    }
}
