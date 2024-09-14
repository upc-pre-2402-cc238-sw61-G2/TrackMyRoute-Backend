namespace backend.tracking;

public interface IBusRouteCommandService
{
    Task<BusRoute?> Handle(CreateBusRouteCommand command);
}