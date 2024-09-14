namespace backend.tracking;

public interface IBusRouteQueryService
{
    Task<IEnumerable<BusRoute>> Handle(GetAllBusRoutesQuery query);
    Task<BusRoute?> Handle(GetBusRouteIdByBusName query);
    Task<BusRoute?> Handle(GetBusRouteByIdQuery query);
}