using Demos.WebformsMVP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos.WebformsMVP.DataAccess.Repositories
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

    /// <summary>
    /// IMPLEMENTATION
    /// </summary>
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDbContext _dbCtx;

        public ActivityRepository(IDbContext dbCtx) 
        {
            _dbCtx = dbCtx ?? throw new ArgumentNullException(nameof(dbCtx));
        }

        public void CreateActivity(Activity newActivity)
        {
            newActivity.Created = newActivity.Updated = DateTime.Now;
            _dbCtx.Set<Activity>().Add(newActivity);
            _dbCtx.SaveChanges();
        }

        public Activity GetByKey(int userProfileId, int activityTypeId, DateTime activityDate)
        {
            return _dbCtx.Set<Activity>()
                .Where(a => a.UserProfileId.Equals(userProfileId) &&
                        a.ActivityTypeId.Equals(activityTypeId) &&
                        a.ActivityDate.Equals(activityDate)).FirstOrDefault();
        }

        public IList<Activity> GetAll(bool onlyPublic)
        {
            throw new NotImplementedException();
        }

        public IList<Activity> GetByTeamname(string teamname)
        {
            return _dbCtx.Set<Activity>()
                .Where(a => a.UserProfile.Team.Trim().ToUpper().Equals(teamname.Trim().ToUpper()))
                .OrderBy(a => a.Created).ToList();
        }

        public IList<Activity> GetByUserProfileId(int userprofileId)
        {
            return _dbCtx.Set<Activity>()
                .Where(a => a.UserProfileId.Equals(userprofileId))
                .OrderBy(a => a.Created).ToList();
        }


        public void Delete(int userProfileId, int activityTypeId, DateTime activityDate)
        {
            var hit = _dbCtx.Set<Activity>()
                .Where(a => a.UserProfileId.Equals(userProfileId) &&
                        a.ActivityTypeId.Equals(activityTypeId) &&
                        a.ActivityDate.Equals(activityDate)).FirstOrDefault();

            if (hit != null)
            {
                _dbCtx.Set<Activity>().Remove(hit);
                _dbCtx.SaveChanges();
            }
            else
                throw new KeyNotFoundException($"Could not find entity with keys, [userProfileId:{userProfileId} activityTypeId:{activityTypeId} activityDate:{activityDate}]");
        }

        public IList<Activity> GetByDepartment(string department)
        {
            return _dbCtx.Set<Activity>()
                .Where(a => a.UserProfile.Department.Trim().ToUpper().Equals(department.Trim().ToUpper()))
                .OrderBy(a => a.Created).ToList();
        }
    }

}