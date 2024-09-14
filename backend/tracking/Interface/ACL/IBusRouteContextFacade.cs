namespace backend.tracking;

public interface IBusRouteContextFacade
{
    Task<int> CreateBusRoute(
        string busName,
        string originName,
        string originCoord, 
        string destinationName,
        string destinationCoord,
        string totalDistance
    );

    
    // Task<string> FetchBusRouteIdByDistance(string distance);
}