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
using Xunit;

namespace IntegrationTests.UnitTests
{
    public class PharmacyPromotionTests
    {
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

        [Fact]
        public void Opens_connection_to_message_queue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();

            connection.ShouldNotBeNull();
        }

        [Fact]
        public void Opens_connection_channel()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.ShouldNotBeNull();
        }
    }
}
