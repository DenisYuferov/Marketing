using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Models;

namespace Marketing.Infrastructure.Repository.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> AllAsync();
        Task<Bank> GetByBicAsync(string bic);
        Task UpsertAsync(Bank Bank);
        Task DeleteAsync(string bic);
    }
}
