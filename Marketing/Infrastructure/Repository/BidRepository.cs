using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketing.Data;
using Marketing.Infrastructure.Repository.Interfaces;
using Marketing.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketing.Infrastructure.Repository
{
    public class BidRepository : IBidRepository
    {
        private readonly MarketingDbContext _marketingDbContext;

        public BidRepository(MarketingDbContext marketingDbContext)
        {
            _marketingDbContext = marketingDbContext;
        }

        public async Task<IEnumerable<Bid>> AllAsync()
        {
            return await _marketingDbContext.Bids.OrderByDescending(b => b.RecordDate).Take(20).
                                             Include(a=>a.Application).Include(b => b.Bank).ToListAsync();
        }

        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _marketingDbContext.Bids.Include(a => a.Application).Include(b => b.Bank).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpsertAsync(Bid bid)
        {
            var existBid = await GetByIdAsync(bid.Id);

            if (existBid == null)
            {
                await _marketingDbContext.Bids.AddAsync(bid);
            }
            else
            {
                existBid.Name = bid.Name;

                existBid.RecordDate = bid.RecordDate;
            }

            await _marketingDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existBid = await GetByIdAsync(id);

            if (existBid == null) return;

            _marketingDbContext.Bids.Remove(existBid);

            await _marketingDbContext.SaveChangesAsync();
        }
    }
}
