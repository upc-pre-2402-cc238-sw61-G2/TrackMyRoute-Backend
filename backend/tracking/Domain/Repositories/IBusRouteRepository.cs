using backend.Shared.Domain.Repositories;

namespace backend.tracking;

public interface IBusRouteRepository : IBaseRepository<BusRoute>
{
    Task<BusRoute?> FindBusRouteIdByNameAsync(string busName);

}