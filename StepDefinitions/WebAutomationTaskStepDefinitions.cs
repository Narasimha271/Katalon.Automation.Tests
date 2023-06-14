using Katalon.Automation.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace Katalon.Automation.Tests.StepDefinitions
{
    [Binding]
    public class WebAutomationTaskStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Page_Cart _page_Cart;
        private readonly Page_KatalonShop _KatalonShop;
        readonly Page_Home _page_Home;

        public WebAutomationTaskStepDefinitions(ScenarioContext scenarioContext, Page_Cart page_Cart, Page_KatalonShop KatalonShop, Page_Home page_Home)
        {
            _scenarioContext = scenarioContext;
            _page_Cart = page_Cart;
            _KatalonShop = KatalonShop;
            _page_Home = page_Home;
        }

        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            _KatalonShop.SelectItem(4);
            _KatalonShop.AddItemToCart();
            _page_Home.NavigateToShop();
            _KatalonShop.SelectItem(2);
            _KatalonShop.AddItemToCart();
            _page_Home.NavigateToShop();
            _KatalonShop.SelectItem(3);
            _KatalonShop.AddItemToCart();
            _page_Home.NavigateToShop();
            _KatalonShop.SelectItem(1);
            _KatalonShop.AddItemToCart();
            _page_Home.NavigateToShop();

        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _page_Home.NavigateToCart();
        }

        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            _page_Cart.NumberofItemsInCart(4).Should().BeTrue();
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            _page_Cart.LowestPriceItem();
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            _page_Cart.RemoveItem();
        }

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {
            _page_Cart.NumberofItemsInCart(3).Should().BeTrue();
        }
    }
}
