namespace backend.tracking;

public record CreateBusRouteResource(
    string BusName,
    string OriginName,
    string OriginCoord,
    string DestinationName,
    string DestinationCoord,
    string TotalDistance
    );