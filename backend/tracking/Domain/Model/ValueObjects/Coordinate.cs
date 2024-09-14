namespace backend.tracking;

public record Coordinate(string Latitude, string Longitude)
{
    public Coordinate() : this(string.Empty, string.Empty)
    {
        
    }
    
    public Coordinate(string latitude) : this(latitude, string.Empty)
    {
        
    }

    public string FullCoordinate => $"{Latitude},{Longitude}";
    
    
}