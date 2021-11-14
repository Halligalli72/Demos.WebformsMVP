using System;
using System.Collections.Generic;
using System.Linq;
namespace Demos.WebformsMVP.DataAccess
{
    /// <summary>
    /// INTERFACE
    /// </summary>
    public interface IActivityTypeRepository
    {
        void CreateType(ActivityType newType);
        ActivityType GetByKey(int key);
        ActivityType GetByName(string name);
        IList<ActivityType> GetAll(bool includeInactive);
    }

    /// <summary>
    /// IMPLEMENTATION
    /// </summary>
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly IDbContext _dbCtx;

        public ActivityTypeRepository(IDbContext dbCtx) 
        {
            _dbCtx = dbCtx ?? throw new ArgumentNullException(nameof(dbCtx));
        }

        public IList<ActivityType> GetAll(bool includeInactive)
        {
            if (includeInactive)
                return _dbCtx.Set<ActivityType>().OrderBy(at => at.Name).ToList();
            else
                return _dbCtx.Set<ActivityType>().Where(at => at.IsActivated.Equals(true)).OrderBy(at => at.Name).ToList();
        }

        public ActivityType GetByKey(int key)
        {
            return _dbCtx.Set<ActivityType>().Where(at => at.ActivityTypeId.Equals(key)).FirstOrDefault();
        }

        public ActivityType GetByName(string name)
        {
            return _dbCtx.Set<ActivityType>().Where(at => at.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public void CreateType(ActivityType newType)
        {
            newType.Created = newType.Updated = DateTime.Now;
            _dbCtx.Set<ActivityType>().Add(newType);
            _dbCtx.SaveChanges();
        }
    }
}
