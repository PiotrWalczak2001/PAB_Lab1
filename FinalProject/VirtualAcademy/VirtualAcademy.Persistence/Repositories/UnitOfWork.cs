using VirtualAcademy.Application.Contracts.Persistence;

namespace VirtualAcademy.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;
        public  IAcademyRepository AcademyRepository { get; private set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            AcademyRepository = new AcademyRepository(_dbContext);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
