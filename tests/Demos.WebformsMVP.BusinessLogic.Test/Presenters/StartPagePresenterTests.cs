using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class StartPagePresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public StartPagePresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SampleTest()
        {
            //Arrange
            var viewMock = new StartPageViewMock();
            var svcMock = new Mock<IActivityService>();
            var testTarget = new StartPagePresenter(viewMock, svcMock.Object);
            //Act

            //Assert

        }







        internal class StartPageViewMock : IStartPageView
        {
            public void DisplayErrorMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayInfoMessage(string msg)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
