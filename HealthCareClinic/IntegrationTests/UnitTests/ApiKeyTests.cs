using System;
using System.Collections.Generic;
using System.Text;
using Integration.ApiKeys.Model;
using Integration.Service.TestServices;
using Moq;
using Shouldly;
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class ApiKeyTests
    {
        [Fact]
        public void Find_all_api_keys()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetApiKeys()).Returns(new List<ApiKey> 
            {   new ApiKey() { Name = "name1", Key = "key1", BaseUrl = "baseUrl1", Category = "category1"}, 
                new ApiKey() { Name = "name2", Key = "key2", BaseUrl = "baseUrl2", Category = "category2" }
            });

            ApiKeyServiceTest service = new ApiKeyServiceTest();

            service.GetNumberOfApiKeys(mockDBContext.Object).ShouldBe(2);
        }
    }
}
