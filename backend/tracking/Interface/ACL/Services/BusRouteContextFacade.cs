namespace backend.tracking;

public class BusRouteContextFacade(
    IBusRouteCommandService busRouteCommandService,
    IBusRouteQueryService busRouteQueryService
    ) : IBusRouteContextFacade
{
    public async Task<int> CreateBusRoute(
        string busName,
        string originName,
        string originCoord, 
        string destinationName,
        string destinationCoord,
        string totalDistance
        )
    {
        var createBusRouteCommand = new CreateBusRouteCommand(
            busName, 
            originName, 
            originCoord, 
            destinationName, 
            destinationCoord, 
            totalDistance);
        var busRoute = await busRouteCommandService.Handle(createBusRouteCommand);
        return busRoute?.Id ?? 0;
    }

}