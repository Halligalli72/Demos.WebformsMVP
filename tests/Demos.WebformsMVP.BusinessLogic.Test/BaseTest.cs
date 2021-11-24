using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestSupport.EfHelpers;

namespace Demos.WebformsMVP.BusinessLogic.Test
{
    public class BaseTest
    {
        private DbContextOptions<DbContext> _options;

        protected WebformsDemoDbContext CreateSimpleTestContext()
        {
            _options = EfInMemory.CreateOptions<DbContext>();
            var context = new WebformsDemoDbContext(_options);
            context.Database.EnsureCreated();
            
            //Seed users
            IList<UserProfile> users = new List<UserProfile> {
                new UserProfile { UserProfileId=1, UserName="adminuser", Name="Admin User", Department="IT", Team="IT Team", IsAdmin=true, IsPublic=true },
                new UserProfile { UserProfileId=2, UserName="testuser", Name="Test User", Department="TestDep", Team="TestTeam", IsAdmin=false, IsPublic=true }
            };
            context.UserProfiles.AddRange(users);

            //Seed activity types
            IList<ActivityType> actTypes = new List<ActivityType> {
                new ActivityType { ActivityTypeId=1, Name="Other", StepValue=1, IsActivated=true },
                new ActivityType { ActivityTypeId=2, Name="Walking", StepValue=1, IsActivated=true },
                new ActivityType { ActivityTypeId=3, Name="Running", StepValue=2, IsActivated=true },
                new ActivityType { ActivityTypeId=4, Name="Cykling", StepValue=2, IsActivated=true },
                new ActivityType { ActivityTypeId=5, Name="Obsolete", StepValue=0, IsActivated=false },
            };
            context.ActivityTypes.AddRange(actTypes);

            //Seed activities
            IList<Activity> activities = new List<Activity> { 
                new Activity { UserProfileId=users[0].UserProfileId, ActivityTypeId=actTypes[0].ActivityTypeId, ActivityDate=DateTime.Now.AddDays(-2),Duration=30, Score=30},
                new Activity { UserProfileId=users[0].UserProfileId, ActivityTypeId=actTypes[1].ActivityTypeId, ActivityDate=DateTime.Now.AddDays(-1),Duration=30, Score=30},
                new Activity { UserProfileId=users[1].UserProfileId, ActivityTypeId=actTypes[2].ActivityTypeId, ActivityDate=DateTime.Now.AddDays(-2),Duration=30, Score=60},
                new Activity { UserProfileId=users[1].UserProfileId, ActivityTypeId=actTypes[3].ActivityTypeId, ActivityDate=DateTime.Now.AddDays(-1),Duration=40, Score=80},
            };
            context.Activities.AddRange(activities);

            context.SaveChanges();
            return context;
        }
    }
}
