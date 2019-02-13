using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Data.Entities;

namespace Marketing.Repository.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> AllAsync();
    }
}
