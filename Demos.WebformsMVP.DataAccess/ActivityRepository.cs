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
    public interface IActivityRepository
    {
        void CreateActivity(Activity newActivity);

        Activity GetByKey(int userProfileId, int activityTypeId, DateTime activityDate);

        IList<Activity> GetByUserProfileId(int userprofileId);

        IList<Activity> GetByTeamname(string teamname);

        IList<Activity> GetAll(bool onlyPublic);

        void Delete(int userProfileId, int activityTypeId, DateTime activityDate);
        IList<Activity> GetByDepartment(string department);
    }


    public class ActivityRepository : IActivityRepository
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static IActivityRepository CreateInstance()
        {
            return new ActivityRepository();
        }

        /// <summary>
        /// Hide default constructor by making it private
        /// </summary>
        private ActivityRepository() { }

        public void CreateActivity(Activity newActivity)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                newActivity.Created = newActivity.Updated = DateTime.Now;
                demoDbContext.Activity.Add(newActivity);
                demoDbContext.SaveChanges();
            }
        }

        public Activity GetByKey(int userProfileId, int activityTypeId, DateTime activityDate)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.Activity
                    .Include("ActivityType")
                    .Include("UserProfile")
                    .Where(a => a.UserProfileId.Equals(userProfileId) && 
                            a.ActivityTypeId.Equals(activityTypeId) && 
                            a.ActivityDate.Equals(activityDate)).FirstOrDefault();
            }
        }

        public IList<Activity> GetAll(bool onlyPublic)
        {
            throw new NotImplementedException();
        }

        public IList<Activity> GetByTeamname(string teamname)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.Activity
                    .Include("ActivityType")
                    .Include("UserProfile")
                    .Where(a => a.UserProfile.Team.Trim().ToUpper().Equals(teamname.Trim().ToUpper()))
                    .OrderBy(a => a.Created).ToList();
            }
        }

        public IList<Activity> GetByUserProfileId(int userprofileId)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.Activity
                    .Include("ActivityType")
                    .Include("UserProfile")
                    .Where(a => a.UserProfileId.Equals(userprofileId))
                    .OrderBy(a => a.Created).ToList();
            }
        }


        public void Delete(int userProfileId, int activityTypeId, DateTime activityDate)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                var hit = demoDbContext.Activity
                    .Where(a => a.UserProfileId.Equals(userProfileId) &&
                            a.ActivityTypeId.Equals(activityTypeId) &&
                            a.ActivityDate.Equals(activityDate)).FirstOrDefault();

                if (hit != null)
                {
                    demoDbContext.Activity.Remove(hit);
                    demoDbContext.SaveChanges();
                }
                else
                    throw new KeyNotFoundException($"Could not find entity with keys, [userProfileId:{userProfileId} activityTypeId:{activityTypeId} activityDate:{activityDate}]");
            }
        }

        public IList<Activity> GetByDepartment(string department)
        {
            using (WebformsMVPDemoEntities demoDbContext = new WebformsMVPDemoEntities())
            {
                return demoDbContext.Activity
                    .Include("ActivityType")
                    .Include("UserProfile")
                    .Where(a => a.UserProfile.Department.Trim().ToUpper().Equals(department.Trim().ToUpper()))
                    .OrderBy(a => a.Created).ToList();
            }
        }
    }

}