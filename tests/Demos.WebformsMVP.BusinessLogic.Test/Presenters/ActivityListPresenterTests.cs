using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class ActivityListPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public ActivityListPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void NotLoggedInUserShouldBeRedirectedToLoginView()
        {
            //Arrange
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(user => user.ID).Returns(0);
            var viewMock = new ActivityListViewMock();
            viewMock.LoggedInUser = userMock.Object;
            var svcMock = new Mock<IActivityService>();
            var testTarget = new ActivityListPresenter(viewMock, svcMock.Object);
            //Act
            testTarget.InitView("");
            //Assert
            Assert.True(viewMock.BeenRedirectedToLoginView);
        }

        [Fact]
        public void LoggedInUserShouldOnlyBeDisplayedOwnActivitiesWhenSelectionIsBlank()
        {
            //Arrange
            const int userId = 1;
            const string selection = "";
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(user => user.ID).Returns(userId);
            var viewMock = new ActivityListViewMock();
            viewMock.LoggedInUser = userMock.Object;
            var svcMock = new Mock<IActivityService>();
            var activities = GetTestActivities();
            svcMock.Setup(ep => ep.GetByUserProfileId(userId)).Returns(GetTestActivities().Where(a => a.UserProfileId.Equals(1)).ToList());
            var testTarget = new ActivityListPresenter(viewMock, svcMock.Object);
            //Act
            testTarget.InitView(selection);
            //Assert
            Assert.True(viewMock.DisplayedActivities.Count > 0);
            foreach (var act in viewMock.DisplayedActivities)
            {
                Assert.Equal(1, act.UserProfileId);
            }
            Assert.Equal("Your own activities", viewMock.ListHeader);
        }




        private IList<IActivity> GetTestActivities() 
        {
            var activities = new List<IActivity>();
            for (int i = 1; i <= 5; i++)
            {
                var act = new ActivityMock { 
                    UserProfileId = i, 
                    Duration = 30 + i,
                    Score = 5 + i,
                    Created = DateTime.Now.AddDays(-i) 
                };
                activities.Add(act);
            }
            return activities;
        }

        internal class ActivityMock : IActivity
        {
            public int UserProfileId { get; set; }
            public IUserInfo Performer { get; set; }
            public DateTime ActivityDate { get; set; }
            public int ActivityTypeId { get; set; }
            public IActivityType ActivityType { get; set; }
            public string OtherActivity { get; set; }
            public int Duration { get; set; }
            public int Score { get; set; }
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
        }


        internal class ActivityListViewMock : IActivityListView
        {
            private IUserInfo _userInfo;
            private string _listHeader;
            public bool BeenRedirectedToLoginView { get; private set; } = false;
            public IList<IActivity> DisplayedActivities { get; private set; }
            public string DisplayedErrorMessage { get; private set; }
            public string DisplayedInfoMessage { get; private set; }


            public IUserInfo LoggedInUser { get => _userInfo; set { _userInfo = value; } }
            public string ListHeader { get => _listHeader; set { _listHeader = value; } }

            public void DisplayActivities(IList<IActivity> activities)
            {
                DisplayedActivities = activities;
            }

            public void DisplayErrorMessage(string msg)
            {
                DisplayedErrorMessage = msg;
            }

            public void DisplayInfoMessage(string msg)
            {
                DisplayedInfoMessage = msg;
            }

            public void RedirectToLoginView()
            {
                BeenRedirectedToLoginView = true;
            }
        }
    }
}
