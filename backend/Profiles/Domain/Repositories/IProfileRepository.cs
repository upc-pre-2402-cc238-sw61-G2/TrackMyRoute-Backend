using backend.Shared.Domain.Repositories;

namespace backend.Profiles;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);

}