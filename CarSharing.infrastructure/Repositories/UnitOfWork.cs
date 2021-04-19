using System.Threading;
using System.Threading.Tasks;
using CarSharing.App.Interfaces;

namespace CarSharing.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarsContext _context;

        public UnitOfWork(CarsContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public ICrudRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            return new CrudRepository<TEntity>(_context);
        }

    }
}
