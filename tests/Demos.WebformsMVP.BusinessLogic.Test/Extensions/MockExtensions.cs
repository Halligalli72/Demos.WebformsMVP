using Demos.WebformsMVP.BusinessLogic.Test.Fakes;
using Demos.WebformsMVP.DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos.WebformsMVP.BusinessLogic.Test.Extensions
{
    internal static class MockExtensions
    {
		internal static void AddEntities<T>(this Mock<IDbContext> ctx, params T[] entities) where T : class
		{
			ThrowExceptionIfContainsDifferentTypes(entities);
			var dbSet = new FakeDbSet<T>();
			dbSet.AddRange(entities);

			ctx.Setup(x => x.Set<T>())
				.Returns(dbSet);
		}

		private static void ThrowExceptionIfContainsDifferentTypes<T>(IEnumerable<T> entities)
		{
			if (entities.Any(e => e.GetType() != entities.First().GetType()))
				throw new ArgumentException("Alla entiteter måste vara av samma typ");
		}

	}
}
