using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.DataAccess
{
    public interface IDbContext : IDisposable
	{
		DbSet<T> Set<T>() where T : class;
		int SaveChanges();

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
