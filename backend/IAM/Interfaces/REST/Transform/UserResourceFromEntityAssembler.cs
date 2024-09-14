using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}