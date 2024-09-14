using backend.IAM.Interfaces.REST.Resources;

namespace backend.IAM.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}