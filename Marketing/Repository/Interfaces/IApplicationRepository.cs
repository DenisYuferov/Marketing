using System.Collections.Generic;
using System.Threading.Tasks;
using Marketing.Data.Tables;

namespace Marketing.Repository.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> All();
    }
}
