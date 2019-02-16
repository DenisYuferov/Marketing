using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Marketing.Data;
using Marketing.Models;
using Marketing.Infrastructure.Repository.Interfaces;

namespace Marketing.Infrastructure.Repository
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
            return await _marketingDbContext.Applications.OrderByDescending(a => a.RecordDate).Take(20).ToListAsync();
        }

        public async Task<Application> GetByCodeAsync(string code)
        {
            return await _marketingDbContext.Applications.FirstOrDefaultAsync(a => a.Code == code);
        }

        public async Task UpsertAsync(Application application)
        {
            var existApplication = await GetByCodeAsync(application.Code);

            if (existApplication == null)
            {
                await _marketingDbContext.Applications.AddAsync(application);
            }
            else
            {
                existApplication.Name = application.Name;
                existApplication.RecordDate = application.RecordDate;
            }
            
            await _marketingDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var existApplication = await GetByCodeAsync(code);

            if (existApplication == null) return;
            
            _marketingDbContext.Applications.Remove(existApplication);

            await _marketingDbContext.SaveChangesAsync();
        }
    }
}
