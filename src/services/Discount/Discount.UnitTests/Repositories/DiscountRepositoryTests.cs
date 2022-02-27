using Discount.Repositories;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Discount.UnitTests.Repositories
{
    [TestFixture]
    public class DiscountRepositoryTests
    {
        private IConfiguration subConfiguration;

        [SetUp]
        public void SetUp()
        {
            this.subConfiguration = Substitute.For<IConfiguration>();
            this.subConfiguration.GetSection("DatabaseSettings:ConnectionString").Value = "Server=localhost;Port=5432;Database=DiscountDb;User Id=admin;Password=admin1234;";
        }

        private DiscountRepository CreateDiscountRepository()
        {
            return new DiscountRepository(
                this.subConfiguration);
        }

        [Test]
        public async Task GetDiscount_Id_1()
        {
            // Arrange
            var discountRepository = this.CreateDiscountRepository();
            string productName = "IPhone X";
            // Act
            var result = await discountRepository.GetDiscount(productName);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
        /*
        [Test]
        public async Task CreateDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountRepository = this.CreateDiscountRepository();
            Coupon coupon = null;

            // Act
            var result = await discountRepository.CreateDiscount(
                coupon);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task UpdateDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountRepository = this.CreateDiscountRepository();
            Coupon coupon = null;

            // Act
            var result = await discountRepository.UpdateDiscount(
                coupon);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task DeleteDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountRepository = this.CreateDiscountRepository();
            string productName = null;

            // Act
            var result = await discountRepository.DeleteDiscount(
                productName);

            // Assert
            Assert.Fail();
        }
        */
    }
}
