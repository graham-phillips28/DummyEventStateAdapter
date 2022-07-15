using EventStateAdapter.RampIdProvider;
using EventStateAdapter.RampIdProvider.Client;
using Moq;
using RestSharp;

namespace RampIdProvider.UnitTests
{
    public class RampIdProviderTests
    {
        [Fact]
        public async Task GetRampId_Test1_RequestUnsuccesful_ReturnMinus1()
        {
            //Arrange
            var restResponse = new RestResponse<RampIdResponse>();
            restResponse.IsSuccessful = false;
            var mockRampClient = new Mock<IRampIdClient>();
            mockRampClient.Setup(x => x.GetIdResponse(It.IsAny<RestRequest>())).Returns(Task.FromResult(restResponse));
            var rampIdProvider = new RampIdResponseProvider(mockRampClient.Object);

            //Act
            long returnedRampId = await  rampIdProvider.GetNewRampId();

            //Assert
            Assert.Equal(-1, returnedRampId);
        }

        [Fact]
        public async Task GetRampId_Test1_RequestSucuccesful_ReturnCorrectId()
        {
            //Arrange
            var restResponse = new RestResponse<RampIdResponse>();
            restResponse.IsSuccessful = true;
            long rampId = 12345;
            restResponse.Data = new RampIdResponse() { List = new List<long> { rampId } };
            var mockRampClient = new Mock<IRampIdClient>();
            mockRampClient.Setup(x => x.GetIdResponse(It.IsAny<RestRequest>())).Returns(Task.FromResult(restResponse));
            var rampIdProvider = new RampIdResponseProvider(mockRampClient.Object);

            //Act
            long returnedRampId = await rampIdProvider.GetNewRampId();

            //Assert
            Assert.Equal(rampId, returnedRampId);
        }
    }
}
