namespace backend.Profiles;

public record StreetAddress(
    string Street,
    string Number,
    string city,
    string PostalCode,
    string country)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, 
        string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street) : this(street, string.Empty, string.Empty, 
        string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string number, string city) : this(street, number, city, 
        string.Empty, string.Empty)
    {
    }
    
    public StreetAddress(string street, string number, string city, string postalCode) : this(street, number, city, 
        postalCode, string.Empty)
    {
    }

    public string FullAddress => $"{Street} {Number}, {city}, {PostalCode}, {country}";
}