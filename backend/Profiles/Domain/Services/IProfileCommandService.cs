namespace backend.Profiles;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}