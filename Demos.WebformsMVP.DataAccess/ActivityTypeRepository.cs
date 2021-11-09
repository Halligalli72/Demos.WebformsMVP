using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Demos.WebformsMVP.DataAccess
{
    /// <summary>
    /// INTERFACE
    /// </summary>
    public interface IActivityTypeRepository
    {
        ActivityType GetByKey(int key);
        IList<ActivityType> GetAll(bool includeInactive);
    }

    /// <summary>
    /// IMPLEMENTATION
    /// </summary>
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static IActivityTypeRepository CreateInstance()
        {
            return new ActivityTypeRepository();
        }

        /// <summary>
        /// Hide default constructor by making it private
        /// </summary>
        private ActivityTypeRepository() { }

        public IList<ActivityType> GetAll(bool includeInactive)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                if (includeInactive)
                    return demoDbContext.ActivityType.OrderBy(at => at.Name).ToList();
                else
                    return demoDbContext.ActivityType.Where(at => at.IsActivated.Equals(true)).OrderBy(at => at.Name).ToList();
            }
        }

        public ActivityType GetByKey(int key)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.ActivityType.Where(at => at.ActivityTypeId.Equals(key)).FirstOrDefault();
            }
        }
    }
}
