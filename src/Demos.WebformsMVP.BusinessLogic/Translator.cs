using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic
{
    /// <summary>
    /// Mapper.
    /// Translates Database objects => Business objects
    /// Translates Business objects => Database objects
    /// </summary>
    public static class Translator
    {
        public static IUserInfo TranslateToBusinessObject(DataAccess.Entities.UserProfile dbobject)
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

        public static IList<IUserInfo> TranslateToBusinessObject(IList<DataAccess.Entities.UserProfile> dbobjectList)
        {
            IList<IUserInfo> boList = new List<IUserInfo>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }

        public static IActivityType TranslateToBusinessObject(DataAccess.Entities.ActivityType dbobject)
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

        public static IList<IActivityType> TranslateToBusinessObject(IList<DataAccess.Entities.ActivityType> dbobjectList)
        {
            IList<IActivityType> boList = new List<IActivityType>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }


        public static IActivity TranslateToBusinessObject(DataAccess.Entities.Activity dbobject)
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

        public static IList<IActivity> TranslateToBusinessObject(IList<DataAccess.Entities.Activity> dbobjectList)
        {
            IList<IActivity> boList = new List<IActivity>();
            foreach (var dbobject in dbobjectList)
            {
                boList.Add(TranslateToBusinessObject(dbobject));
            }
            return boList;
        }


        public static DataAccess.Entities.UserProfile TranslateToDatabaseObject(IUserInfo bo)
        {
            DataAccess.Entities.UserProfile dbObject = new DataAccess.Entities.UserProfile
            {
                UserProfileId = bo.ID,
                UserName = bo.UserName,
                Name = bo.Name,
                Team = bo.TeamName,
                Department = bo.Department,
                IsPublic = bo.ResultsArePublic,
                Created = bo.Created,
                Updated = bo.Updated
            };
            return dbObject;
        }

        public static DataAccess.Entities.ActivityType TranslateToDatabaseObject(IActivityType bo) 
        {
            DataAccess.Entities.ActivityType dbObject = new DataAccess.Entities.ActivityType
            {
                Name = bo.ActivityName,
                StepValue = bo.Steps,
                IsActivated = bo.IsActivated,
                Created = bo.Created,
                Updated = bo.Updated
            };
            return dbObject;
        }

        public static DataAccess.Entities.Activity TranslateToDatabaseObject(IActivity bo)
        {
            DataAccess.Entities.Activity dbObject = new DataAccess.Entities.Activity
            {
                ActivityDate = bo.ActivityDate,
                ActivityTypeId = bo.ActivityTypeId,
                OtherActivity = bo.OtherActivity,
                Duration = bo.Duration,
                UserProfileId = bo.UserProfileId,
                Score = bo.Score,
                Created = bo.Created,
                Updated = bo.Updated
            };
            return dbObject;
        }



    }
}
