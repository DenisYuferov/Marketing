using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Data.Tables;

namespace Marketing.Repository.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> All();
    }
}
