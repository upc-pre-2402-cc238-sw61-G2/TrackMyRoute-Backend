using backend.Shared.Domain.Repositories;

namespace backend.Profiles;

public class ProfileCommandService(IProfileRepository profileRepository,
    IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the profile: { e.Message}");
            return null;
        }
    }
}