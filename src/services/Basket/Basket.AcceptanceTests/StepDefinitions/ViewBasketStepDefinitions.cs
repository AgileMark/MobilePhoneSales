using System;
using Basket.Controllers;
using Basket.Entities;
using Basket.Repositories;
using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Basket.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ViewBasketStepDefinitions
    {
        private ShoppingCart _basket;

        [SetUp]
        public void SetUp()
        {

        }

        private ShoppingCart CreateBasket(string userName, List<ShoppingCartItem> shoppingCartItems)
        {
            var subBasketRepository = Substitute.For<IBasketRepository>();
            var basket = new ShoppingCart(userName);
            basket.Items = shoppingCartItems;
            subBasketRepository.GetBasket(userName).ReturnsForAnyArgs(basket);
            var basketController = new BasketController(subBasketRepository);
            //basketController.GetBasket(userName)

            return basket;
        }

        [Given(@"I have not added any products to my basket")]
        public void GivenIHaveNotAddedAnyProductsToMyBasket()
        {

            List<ShoppingCartItem> basketItems = new List<ShoppingCartItem>();
            _basket = CreateBasket("", basketItems);
        }

        [When(@"I view the basket page")]
        public void WhenIViewTheBasketPage()
        {

        }

        [Then(@"I should see no products in my basket")]
        public void ThenIShouldSeeNoProductsInMyBasket()
        {
            Assert.That(_basket.Items.Count, Is.EqualTo(0));
        }

        [Given(@"I have added (.*) iPhoneX to my basket")]
        public void GivenIHaveAddedIPhoneXToMyBasket(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I should see the iPhoneX")]
        public void ThenIShouldSeeTheIPhoneX()
        {
            throw new PendingStepException();
        }

        [Then(@"the quantity shown should be (.*)")]
        public void ThenTheQuantityShownShouldBe(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have added an iPhoneX and another product to my basket")]
        public void GivenIHaveAddedAnIPhoneXAndAnotherProductToMyBasket()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see an iPhoneX")]
        public void ThenIShouldSeeAnIPhoneX()
        {
            Assert.That(_basket, Is.EqualTo("iPhoneX"));
        }

        [Then(@"another product")]
        public void ThenAnotherProduct()
        {
            throw new PendingStepException();
        }
    }
}
