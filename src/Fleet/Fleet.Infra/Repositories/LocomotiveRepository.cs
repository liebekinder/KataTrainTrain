using Fleet.Infra.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Fleet.Infra.Repositories;

public sealed class LocomotiveRepository
{
    private readonly FleetContext _context;

    public LocomotiveRepository(FleetContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<DbLocomotive>> GetAllAsync()
    {
        return await _context.Set<DbLocomotive>().ToListAsync();
    }

    public async Task<DbLocomotive?> GetByIdAsync(int locomotiveId)
    {
        return await _context.Set<DbLocomotive>().FindAsync(locomotiveId);
    }

    public async Task DeleteByIdAsync(int locomotiveId)
    {
        var locomotive = await _context.Set<DbLocomotive>()
            .FindAsync(locomotiveId);

        if (locomotive is not null)
        {
            _context.Set<DbLocomotive>().Remove(locomotive);
        }

        await _context.SaveChangesAsync();
    }
}

