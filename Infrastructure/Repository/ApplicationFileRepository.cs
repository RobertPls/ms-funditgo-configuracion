using Domain.Model;
using Domain.Repository;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

internal class ApplicationFileRepository : IApplicationFileRepository
{
    private readonly WriteDbContext _dbContext;

    public ApplicationFileRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(ApplicationFile obj)
    {
        await _dbContext.ApplicationFiles.AddAsync(obj);
    }

    public Task<ApplicationFile?> FindByIdAsync(Guid id)
    {
        return _dbContext.ApplicationFiles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(ApplicationFile file)
    {
        _dbContext.ApplicationFiles.Update(file);
        return Task.CompletedTask;
    }
}
