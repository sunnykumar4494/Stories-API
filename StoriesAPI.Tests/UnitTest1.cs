using BusinessLayer;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using Xunit;

namespace StoriesAPI.Tests
{
    public class HackerNewsTest
    {
        [Fact]
        public void TestTopStoriesId()
        {
            //Assert
            var responseMessage2 = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject("{\r\n  \"by\" : \"danzheng\",\r\n  \"descendants\" : 162,\r\n  \"id\" : 37793635,\r\n  \"kids\" : [ 37795443, 37794916, 37798025, 37794165, 37798030, 37797478, 37794750, 37794933, 37794569, 37795259, 37795847, 37794735, 37794749, 37795823, 37795149, 37797570, 37796631, 37795969, 37795569, 37797442, 37796912, 37794673, 37795005, 37794442, 37795689, 37796009, 37797296, 37794759, 37795992 ],\r\n  \"score\" : 273,\r\n  \"time\" : 1696613736,\r\n  \"title\" : \"AMD may get across the CUDA moat\",\r\n  \"type\" : \"story\",\r\n  \"url\" : \"https://www.hpcwire.com/2023/10/05/how-amd-may-get-across-the-cuda-moat/\"\r\n}"))
            };

            var mock = new Mock<HttpMessageHandler>();
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                 ItExpr.Is<HttpRequestMessage>(
                   m => m.RequestUri.AbsolutePath.Contains("https://hacker-news.firebaseio.com/v0")),
                    ItExpr.IsAny<CancellationToken>())
                  .ReturnsAsync(responseMessage2);


            var client = new HttpClient(mock.Object);
            HackerNews  _hkernews=new HackerNews();
            var actual=_hkernews.TopStoriesId();
            Assert.True(actual.Result!=null);
        }
    }
}