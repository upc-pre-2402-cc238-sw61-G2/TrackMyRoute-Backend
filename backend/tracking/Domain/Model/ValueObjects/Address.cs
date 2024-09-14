namespace backend.tracking;

public record Address(string Street, string Number, string City, string State)
{
    public Address() : this(string.Empty, string.Empty, string.Empty)
    {
        
    }

    public Address(string street) : this(street, string.Empty, string.Empty)
    {
        
    }

    public Address(string street, string number, string city) : this(street, number, city, string.Empty)
    {
        
    }

    public string FullAddress => $"{Street} {Number}, {City}, {State}";
}