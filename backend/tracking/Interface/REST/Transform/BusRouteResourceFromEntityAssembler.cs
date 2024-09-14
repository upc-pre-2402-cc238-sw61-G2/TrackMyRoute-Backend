namespace backend.tracking;

public class BusRouteResourceFromEntityAssembler
{
    public static BusRouteResource ToResourceFromEntity(BusRoute entity)
    {
        return new BusRouteResource(
            entity.Id,
            entity.BusName,
            entity.OriginName,
            entity.OriginCoord,
            entity.DestinationName,
            entity.DestinationCoord,
            entity.TotalDistance
        );
    }
}