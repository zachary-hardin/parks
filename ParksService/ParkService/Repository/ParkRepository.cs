using Microsoft.EntityFrameworkCore;
using ParksService.Data;
using ParksService.Models;

namespace ParksService.Repository;

public interface IParkRepository
{
    Task<IEnumerable<Park>> GetAllAsync();
}

public class ParkRepository : IParkRepository
{
    private readonly ParksDbContext _context;

    public ParkRepository(ParksDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Park>> GetAllAsync()
    {
        return await _context.Parks.AsNoTracking().ToListAsync();
    }
}