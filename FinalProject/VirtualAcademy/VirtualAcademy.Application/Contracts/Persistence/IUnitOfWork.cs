namespace VirtualAcademy.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
        void Dispose();
    }
}
