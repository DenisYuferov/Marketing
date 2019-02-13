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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly MarketingDbContext _marketingDbContext;

        public ApplicationRepository(MarketingDbContext marketingDbContext)
        {
            _marketingDbContext = marketingDbContext;

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            var isThereApps = await _marketingDbContext.Applications.AnyAsync();

            if (isThereApps) return;
            
            for (var i = 1; i <= 1000; i++)
            {
                var app = new Application{Code = $"AP-{i}" , Name = $"Приложение {i}", RecordDate = DateTime.Now };

                await _marketingDbContext.AddAsync(app);
            }

            await _marketingDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Application>> AllAsync()
        {
            return await _marketingDbContext.Applications.OrderBy(a => a.RecordDate).ToListAsync();
        }
    }
}
