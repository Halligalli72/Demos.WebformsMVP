using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// INTERFACE
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IActivityService
    {
        void Save(IActivity act);
        IList<IActivity> GetByUserProfileId(int userprofileId);
        IList<IActivity> GetByDepartment(string department);
        IList<IActivity> GetByTeam(string teamname);
        IActivity GetByKeys(int userProfileId, int activityTypeId, DateTime timestamp);
        void Delete(IActivity hit);
    }
}

/// <summary>
/// IMPLEMENTATION
/// </summary>
namespace Demos.WebformsMVP.BusinessLogic.Services
{
    public class ActivityService : IActivityService
    {
        private DataAccess.Repositories.IActivityRepository _repo = null;

        public ActivityService(DataAccess.Repositories.IActivityRepository activityRepo)
        {
            _repo = activityRepo ?? throw new ArgumentNullException(nameof(activityRepo));
        }

        private ActivityService() { }

        public void Delete(IActivity activity)
        {
            _repo.Delete(activity.UserProfileId, activity.ActivityTypeId, activity.ActivityDate);
        }

        public IList<IActivity> GetByDepartment(string department)
        {
            return Translator.TranslateToBusinessObject(_repo.GetByDepartment(department));
        }

        public IActivity GetByKeys(int userProfileId, int activityTypeId, DateTime activityDate)
        {
            return Translator.TranslateToBusinessObject(_repo.GetByKey(userProfileId, activityTypeId, activityDate));
        }

        public IList<IActivity> GetByTeam(string teamname)
        {
            return Translator.TranslateToBusinessObject(_repo.GetByTeamname(teamname));
        }

        public IList<IActivity> GetByUserProfileId(int userprofileId)
        {
            return Translator.TranslateToBusinessObject(_repo.GetByUserProfileId(userprofileId));
        }

        public void Save(IActivity act)
        {
            act.Score = Helper.CalculateScore(act.Duration);
            _repo.CreateActivity(Translator.TranslateToDatabaseObject(act));
        }
    }
}
