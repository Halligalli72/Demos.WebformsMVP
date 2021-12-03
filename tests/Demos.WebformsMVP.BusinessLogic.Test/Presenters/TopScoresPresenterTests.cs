using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class TopScoresPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public TopScoresPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SampleTest()
        {
            //Arrange
            var viewMock = new TopScoresViewMock();
            var svcMock = new Mock<IActivityService>();
            var testTarget = new TopScoresPresenter(viewMock, svcMock.Object);
            //Act

            //Assert

        }












        internal class TopScoresViewMock : ITopScoresView
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
