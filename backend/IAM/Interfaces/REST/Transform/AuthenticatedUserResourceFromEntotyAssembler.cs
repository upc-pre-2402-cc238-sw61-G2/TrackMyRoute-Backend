using backend.IAM.Interfaces.REST.Resources;
using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public class AuthenticatedUserResourceFromEntotyAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}