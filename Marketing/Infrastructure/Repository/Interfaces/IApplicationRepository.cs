using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Models;

namespace Marketing.Infrastructure.Repository.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> AllAsync();
        Task<Application> GetByCodeAsync(string code);
        Task UpsertAsync(Application application);
        Task DeleteAsync(string code);
    }
}
