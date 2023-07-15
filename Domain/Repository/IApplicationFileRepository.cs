using Domain.Model;
using Shared.Core;

namespace Domain.Repository
{
    public interface IApplicationFileRepository : IRepository<ApplicationFile, Guid>
    {
        public Task UpdateAsync(ApplicationFile file);
    }
}
