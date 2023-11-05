namespace BackEnd_ApiTech.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}