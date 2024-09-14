namespace backend.tracking;

public record BusRouteResource(
    int Id, 
    string BusName,
    string OriginName,
    string OriginCoord,
    string DestinationName,
    string DestinationCoord,
    string TotalDistance
    );