using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using Integration.Service;
using Moq;
using RabbitMQ.Client;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Integration.Promotions.Model;
using Integration.Promotions.Service;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace IntegrationTests.UnitTests
{
    public class PharmacyPromotionTests
    {
        public PharmacyPromotionTests()
        {
            using (var file = File.OpenText(GetPath()))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }

        [Fact]
        public void Gets_all_pharmacy_promotions()
        {
            var stubRepository = new Mock<IPharmacyPromotionRepository>();

            List<PharmacyPromotion> pharmacyPromotions = new List<PharmacyPromotion> {
                new PharmacyPromotion(1, "Best prices", "We have best prices", new DateTime(2021, 11, 23), new DateTime(2021, 11, 25), false, "Benu")
            };

            stubRepository.Setup(t => t.GetAll()).Returns(pharmacyPromotions);

            var pharmacyPromotionService = new PharmacyPromotionService(stubRepository.Object);

            ((List<PharmacyPromotion>)pharmacyPromotionService.GetAll()).Count.ShouldBe(1);
        }

        [SkippableFact]
        public void Opens_connection_to_message_queue()
        {
            Skip.IfNot(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"));
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();

            connection.ShouldNotBeNull();
        }

        [SkippableFact]
        public void Opens_connection_channel()
        {
            Skip.IfNot(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"));
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.ShouldNotBeNull();
        }

        private string GetPath()
        {
            string folderName = Path.Combine("Properties", "launchSettings.json");
            string rootDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string path = Path.Combine(rootDirectory, folderName);

            return path;
        }
    }
}
