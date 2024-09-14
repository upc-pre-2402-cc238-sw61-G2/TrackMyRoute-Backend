namespace backend.tracking.Domain.Model.ValueObjects;

public record Stop(Coordinate Location, Address Address, TimeWindow TimeWindow)
{
    public Stop() : this(
        new Coordinate("0", "0"), 
            new Address("Default Street", "Default City", "Default State", "00000"),
            new TimeWindow(DateTime.MinValue, DateTime.MaxValue))
    {

    }
}