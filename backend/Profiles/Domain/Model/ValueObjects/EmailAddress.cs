namespace backend.Profiles;

public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty)
    {
        
    }
}