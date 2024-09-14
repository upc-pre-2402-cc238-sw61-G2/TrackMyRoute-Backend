namespace backend.Profiles;

public record CreateProfileCommand(string firstName, string lastName, string email,
    string street,
    string number,
    string city,
    string postalCode,
    string country);