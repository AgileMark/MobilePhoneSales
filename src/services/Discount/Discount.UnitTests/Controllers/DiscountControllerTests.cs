using Discount.Controllers;
using Discount.Entities;
using Discount.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Discount.UnitTests.Controllers
{
    [TestFixture]
    public class DiscountControllerTests
    {
        private IDiscountRepository subDiscountRepository;

        [SetUp]
        public void SetUp()
        {
            this.subDiscountRepository = Substitute.For<IDiscountRepository>();
        }

        private DiscountController CreateDiscountController()
        {
            var coupon = new Coupon() { Amount  = 100,Description = "Iphone" , Id = 1, ProductName = ""};
            subDiscountRepository.GetDiscount(Arg.Any<string>()).ReturnsForAnyArgs(coupon);
 
            return new DiscountController(this.subDiscountRepository);
        }

        [Test]
        public async Task GetDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //discountController
            var sut = this.CreateDiscountController();
            
            string productName = Arg.Any<string>();

            // Act
            ActionResult<Coupon> actionResult = await sut.GetDiscount(productName);
            //Task<ActionResult<Coupon>> actionResult = await sut.GetDiscount(productName);
            //var result = await sut.GetDiscount(productName);

            // Assert
            //Assert.That(actionResult.Result, Is.EqualTo(StatusCodes.Status200OK));
            //Assert.That(typeof(actionResult.Result), Is.EqualTo(typeof(OkObjectResult)));
            Assert.That(actionResult.Value, Is.EqualTo(productName));
        }
        /*
        [Test]
        public async Task CreateDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountController = this.CreateDiscountController();
            Coupon coupon = null;

            // Act
            var result = await discountController.CreateDiscount(
                coupon);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task UpdateBasket_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountController = this.CreateDiscountController();
            Coupon coupon = null;

            // Act
            var result = await discountController.UpdateBasket(
                coupon);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task DeleteDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var discountController = this.CreateDiscountController();
            string productName = null;

            // Act
            var result = await discountController.DeleteDiscount(
                productName);

            // Assert
            Assert.Fail();
        }
        */
    }
}
