using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Models;

namespace Marketing.Infrastructure.Repository.Interfaces
{
    public interface IBidRepository
    {
        Task<IEnumerable<Bid>> AllAsync();
        Task<Bid> GetByIdAsync(int id);
        Task UpsertAsync(Bid bid);
        Task DeleteAsync(int id);
    }
}
