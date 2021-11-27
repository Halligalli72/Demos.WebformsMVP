using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Moq;
using System.Collections.Generic;
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
        public void SampleTest()
        {
            //Arrange
            var viewMock = new ActivityListViewMock();
            var svcMock = new Mock<IActivityService>();
            var testTarget = new ActivityListPresenter(viewMock, svcMock.Object);
            //Act

            //Assert

        }










        internal class ActivityListViewMock : IActivityListView
        {
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string ListHeader { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public void DisplayActivities(IList<IActivity> activities)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayErrorMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayInfoMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void RedirectToLoginView()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
