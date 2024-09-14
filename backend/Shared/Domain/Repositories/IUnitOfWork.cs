namespace backend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}