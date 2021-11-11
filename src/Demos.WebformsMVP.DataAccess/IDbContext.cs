using System;
using System.Data.Entity;

namespace Demos.WebformsMVP.DataAccess
{
    public interface IDbContext : IDisposable
	{
		IDbSet<T> Set<T>() where T : class;

		int SaveChanges();
	}
}
