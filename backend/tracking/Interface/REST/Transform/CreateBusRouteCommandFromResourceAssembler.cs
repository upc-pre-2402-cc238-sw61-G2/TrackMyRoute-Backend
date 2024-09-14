namespace backend.tracking;

public class CreateBusRouteCommandFromResourceAssembler
{
    public static CreateBusRouteCommand ToCommandFromResource(CreateBusRouteResource resource)
    {
        return new CreateBusRouteCommand(
            resource.BusName,
            resource.OriginName,
            resource.OriginCoord,
            resource.DestinationName,
            resource.DestinationCoord,
            resource.TotalDistance
        );
    }
}