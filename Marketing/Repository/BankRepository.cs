using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Marketing.Data;
using Marketing.Data.Entities;
using Marketing.Repository.Interfaces;

namespace Marketing.Repository
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
            return await _marketingDbContext.Banks.OrderBy(b => b.RecordDate).ToListAsync();
        }
    }
}
