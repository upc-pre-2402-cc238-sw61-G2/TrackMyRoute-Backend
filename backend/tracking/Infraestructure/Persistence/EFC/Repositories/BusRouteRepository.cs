using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.tracking;

public class BusRouteRepository(AppDbContext context) : BaseRepository<BusRoute>(context), IBusRouteRepository
{
    public Task<BusRoute?> FindBusRouteIdByNameAsync(string busName)
    {
        return Context.Set<BusRoute>().FirstOrDefaultAsync(b => b.BusName == busName);
    }
    
}