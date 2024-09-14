namespace backend.tracking;

public record TimeWindow(DateTime Start, DateTime End)
{
    
    public TimeWindow() : this(DateTime.Now, DateTime.Now)
    {
    }
}