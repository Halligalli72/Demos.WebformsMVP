using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class RegisterActivityPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public RegisterActivityPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void NotLoggedInUserShouldBeRedirectedToLoginView()
        {
            //Arrange
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(user => user.ID).Returns(0);
            var viewMock = new RegisterActivityViewMock();
            viewMock.LoggedInUser = userMock.Object;
            var actSvcMock = new Mock<IActivityService>();
            var actTypeSvcMock = new Mock<IActivityTypeService>();
            var testTarget = new RegisterActivityPresenter(viewMock, actSvcMock.Object, actTypeSvcMock.Object);
            //Act
            testTarget.InitView();
            //Assert
            Assert.True(viewMock.BeenRedirectedToLoginView);
        }

        [Fact]
        public void LoggedInUserShouldBeServedPreparedForm()
        {
            //Arrange
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(user => user.ID).Returns(1);
            userMock.Setup(user => user.UserName).Returns("MYUSERNAME");
            var viewMock = new RegisterActivityViewMock();
            viewMock.LoggedInUser = userMock.Object;
            var actSvcMock = new Mock<IActivityService>();
            var actTypeSvcMock = new Mock<IActivityTypeService>();
            actTypeSvcMock.Setup(svc => svc.GetAll(false)).Returns(GetTestActivityTypes());
            var testTarget = new RegisterActivityPresenter(viewMock, actSvcMock.Object, actTypeSvcMock.Object);
            //Act
            testTarget.InitView();
            //Assert
            Assert.Equal("MYUSERNAME", viewMock.UserName);
            Assert.Equal(DateTime.Now.ToShortDateString(), viewMock.ActivityDateInput);
            Assert.True(viewMock.DisplayedActivityTypes.Count > 0);
            Assert.Equal(30, viewMock.DurationInput);
        }


        private IList<IActivityType> GetTestActivityTypes()
        {
            var actTypes = new List<IActivityType>();
            for (int i = 1; i <= 5; i++)
            {
                var act = new ActivityTypeMock
                {
                    ID = i,
                    ActivityName = $"Type {i}",
                    IsActivated = true,
                    Steps=20 + i,
                    Created = DateTime.Now.AddDays(-i),
                    Updated = DateTime.Now.AddDays(-i)
                };
                actTypes.Add(act);
            }
            return actTypes;
        }

        internal class ActivityTypeMock : IActivityType
        {
            public int ID { get; set; }
            public string ActivityName { get; set; }
            public int Steps { get; set; }
            public bool IsActivated { get; set; }
            public DateTime Created { get; set; }
            public DateTime Updated { get; set; }
        }

        internal class RegisterActivityViewMock : IRegisterActivityView
        {
            private IUserInfo _userInfo;
            private string _userName;
            private string _activityDateInput;
            private string _otherActivityNameInput;
            private int _durationInput;
            public bool BeenRedirectedToLoginView { get; private set; } = false;
            public bool BeenRedirectAfterSaveOK { get; private set; } = false;
            public string DisplayedErrorMessage { get; private set; }
            public string DisplayedInfoMessage { get; private set; }
            public IList<IActivityType> DisplayedActivityTypes { get; private set; }

            public IUserInfo LoggedInUser { get { return _userInfo; } set { _userInfo = value; } }
            public string UserName { get { return _userName; } set { _userName = value; } }

            public int SelectedActivityIdInput { get; private set; }

            public string OtherActivityNameInput { get { return _otherActivityNameInput; } set { _otherActivityNameInput = value; } }
            public string ActivityDateInput { get { return _activityDateInput; } set { _activityDateInput = value; } }
            public int DurationInput { get { return _durationInput; } set { _durationInput = value; } }

            public void DisplayErrorMessage(string msg)
            {
                DisplayedErrorMessage = msg;
            }

            public void DisplayInfoMessage(string msg)
            {
                DisplayedInfoMessage = msg;
            }

            public void InitAvailableActivityTypes(IList<IActivityType> activityTypes)
            {
                DisplayedActivityTypes = activityTypes;
            }

            public void RedirectAfterSaveOK()
            {
                BeenRedirectAfterSaveOK = true;
            }

            public void RedirectToLoginView()
            {
                BeenRedirectedToLoginView = true;
            }
        }
    }
}
