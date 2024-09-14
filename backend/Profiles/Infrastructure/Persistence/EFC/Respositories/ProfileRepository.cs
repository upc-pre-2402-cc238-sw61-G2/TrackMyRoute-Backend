using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Profiles;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenter_Platform.Profiles;

public class ProfileRepository(AppDbContext context) :
    BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email)
            .FirstOrDefaultAsync();
    }
    
}