namespace backend.Profiles;

public partial class Profile
{
    public int Id { get;  }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;
    
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }

    public Profile(string firstName, string lastName, string email,
        string street,
        string number,
        string city,
        string postalCode,
        string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.firstName, command.lastName);
        Email = new EmailAddress(command.email);
        Address = new StreetAddress(command.street, command.number, command.city, 
            command.postalCode, command.country);
    }
}