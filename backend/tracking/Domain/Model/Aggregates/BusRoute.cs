namespace backend.tracking;

public partial class BusRoute
{
    public int Id { get; private set; }
    public string BusName { get; private set; }
    public string OriginName { get; private set; }
    public string OriginCoord { get; private set; }
    public string DestinationName { get; private set; }
    public string DestinationCoord { get; private set; }
    
    // public List<Stop> Stops { get; private set; }
    public string TotalDistance { get; private set; }

    public BusRoute()
    {
        BusName = " ";
        OriginName = "";
        OriginCoord = "";
        DestinationName = "";
        DestinationCoord = "";
        // Stops = new List<Stop>();
        TotalDistance = " ";
    }
    
    // Falta agregar stops y timewindow
    public BusRoute(
        string busName,
        string originName,
        string originCoord, 
        string destinationName,
        string destinationCoord,
        string totalDistance
        )
    {
        BusName = busName;
        OriginName = originName;
        OriginCoord = originCoord;
        DestinationName = destinationName;
        DestinationCoord = destinationCoord;
        TotalDistance = totalDistance;

        // Stops = new List<Stop>(location, address, timeWindow);

    }


    public BusRoute(CreateBusRouteCommand command)
    {
        BusName = command.busName;
        OriginName = command.originName;
        OriginCoord = command.originCoord;
        DestinationName = command.destinationName;
        DestinationCoord = command.destinationCoord;
        TotalDistance = command.totalDistance;
    }
}