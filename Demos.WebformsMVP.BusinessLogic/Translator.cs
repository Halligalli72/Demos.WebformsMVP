using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic
{
    public static class Translator
    {
        public static IUserInfo TranslateToBusinessObject(DataAccess.UserProfile dbobject)
        {
            IUserInfo bo = Factory.CreateUserInfo();
            bo.ID = dbobject.UserProfileId;
            bo.UserName = dbobject.UserName;
            bo.Name = dbobject.Name;
            bo.TeamName = dbobject.Team;
            bo.Department = dbobject.Department;
            bo.IsAdmin = dbobject.IsAdmin;
            bo.ResultsArePublic = dbobject.IsPublic;
            bo.Created = dbobject.Created;
            bo.Updated = dbobject.Updated;
            return bo;
        }

        public static IList<IUserInfo> TranslateToBusinessObject(IList<DataAccess.UserProfile> dbobjectList)
        {
            IList<IUserInfo> boList = new List<IUserInfo>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }

        public static IActivityType TranslateToBusinessObject(DataAccess.ActivityType dbobject)
        {
            IActivityType bo = Factory.CreateActivityType();
            bo.ID = dbobject.ActivityTypeId;
            bo.ActivityName = dbobject.Name;
            bo.Steps = dbobject.StepValue;
            bo.IsActivated = dbobject.IsActivated;
            bo.Created = dbobject.Created;
            bo.Updated = dbobject.Updated;
            return bo;
        }

        public static IList<IActivityType> TranslateToBusinessObject(IList<DataAccess.ActivityType> dbobjectList)
        {
            IList<IActivityType> boList = new List<IActivityType>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }


        public static IActivity TranslateToBusinessObject(DataAccess.Activity dbobject)
        {
            IActivity bo = Factory.CreateActivity();
            bo.ActivityDate = dbobject.ActivityDate;
            bo.ActivityTypeId = dbobject.ActivityTypeId;
            bo.ActivityType = TranslateToBusinessObject(dbobject.ActivityType); //Must be included for this to work
            bo.UserProfileId = dbobject.UserProfileId;
            bo.Performer = TranslateToBusinessObject(dbobject.UserProfile);     //Must be included for this to work
            bo.OtherActivity = dbobject.OtherActivity;
            bo.Duration = dbobject.Duration;
            bo.Score = dbobject.Score;
            bo.Created = dbobject.Created;
            bo.Updated = dbobject.Updated;
            return bo;
        }

        public static IList<IActivity> TranslateToBusinessObject(IList<DataAccess.Activity> dbobjectList)
        {
            IList<IActivity> boList = new List<IActivity>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }


        public static DataAccess.UserProfile TranslateToDatabaseObject(IUserInfo bo)
        {
            DataAccess.UserProfile dbObject = new DataAccess.UserProfile();
            dbObject.UserProfileId = bo.ID;
            dbObject.UserName = bo.UserName;
            dbObject.Name = bo.Name;
            dbObject.Team = bo.TeamName;
            dbObject.Department = bo.Department;
            dbObject.IsPublic = bo.ResultsArePublic;
            dbObject.Created = bo.Created;
            dbObject.Updated = bo.Updated;
            return dbObject;
        }

        public static DataAccess.Activity TranslateToDatabaseObject(IActivity act)
        {
            DataAccess.Activity dbObject = new DataAccess.Activity();
            dbObject.ActivityDate = act.ActivityDate;
            dbObject.ActivityTypeId = act.ActivityTypeId;
            dbObject.OtherActivity = act.OtherActivity;
            dbObject.Duration = act.Duration;
            dbObject.UserProfileId = act.UserProfileId;
            dbObject.Score = act.Score;
            dbObject.Created = act.Created;
            dbObject.Updated = act.Updated;
            return dbObject;
        }



    }
}
