namespace backend.Profiles;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress,
            entity.StreetAddress);
    }
}