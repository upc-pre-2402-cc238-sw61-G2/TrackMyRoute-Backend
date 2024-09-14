namespace backend.tracking;

public class BusRouteQueryService(IBusRouteRepository busRouteRepository) : IBusRouteQueryService
{
    public async Task<IEnumerable<BusRoute>> Handle(GetAllBusRoutesQuery query)
    {
        return await busRouteRepository.ListAsync();
    }
    

    public async Task<BusRoute?> Handle(GetBusRouteByIdQuery query)
    {
        return await busRouteRepository.FindByIdAsync(query.busRouteId);
    }
    
    public async Task<BusRoute?> Handle(GetBusRouteIdByBusName query)
    {
        return await busRouteRepository.FindBusRouteIdByNameAsync(query.BusName);
    }
    
}