using backend.Shared.Domain.Repositories;

namespace backend.IAM;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}