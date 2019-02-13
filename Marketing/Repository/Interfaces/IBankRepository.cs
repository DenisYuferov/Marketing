using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Data.Entities;

namespace Marketing.Repository.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> AllAsync();
    }
}
