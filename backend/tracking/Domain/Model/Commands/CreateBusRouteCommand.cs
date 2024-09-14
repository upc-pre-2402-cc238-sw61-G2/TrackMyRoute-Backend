namespace backend.tracking;

public record CreateBusRouteCommand(
    string busName,
    string originName,
    string originCoord, 
    string destinationName,
    string destinationCoord,
    string totalDistance
    );