using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;
using OddsGG_RegistrationForm;

namespace OddGG_MainPage_Tests
{
    [TestClass]
    public class OddsGGMainPageTests
    {

        public OddsGGMainPageTests()
        {
            Driver = new FirefoxDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            MainPage = new OddsGGMainPage();
            RegistrationForm = new OddsGGRegistrationForm();
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public OddsGGMainPage MainPage { get; set; }
        public OddsGGRegistrationForm RegistrationForm { get; set; }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, RegistrationForm);
            Driver.Navigate().GoToUrl(MainPage.url);
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void ClickOnOddsGGLogo()
        {
            MainPage.LogoSign.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("logo-txt")));

            string expectedPageTitle = "ODDS.GG";
            var currentPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, currentPageTitle);
        }

        [TestMethod]
        public void ClickOnWhatWeOfferButton()
        {
            MainPage.ClickOnWhatWeOfferButton();
        }

        [TestMethod]
        public void ClickOnWhoWeAreButton()
        {
            MainPage.ClickOnWhoWeAreButton();
        }

        [TestMethod]
        public void ClickOnApiDocsButton()
        {
            string expectedLoginFormText = "ODDS.GG";

            MainPage.ClickOnApiDocsButton();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            var actualLoginFormText = Driver.FindElement(By.ClassName("logo-txt")).Text;

            Assert.AreEqual(expectedLoginFormText, actualLoginFormText);
        }

        [TestMethod]
        public void ClickOnSignupButton()
        {
            string exptectedSignUpButtonText = "ODDS.GG";

            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));
            var actualSignupFormText = Driver.FindElement(By.ClassName("logo-txt")).Text;

            Assert.AreEqual(exptectedSignUpButtonText, actualSignupFormText);
        }

        [TestMethod]
        public void ClickOnLoginButton()
        {
            string expectedLoginFormText = "ODDS.GG";

            MainPage.ClickOnLoginButton();

            MainPage.ClickOnApiDocsButton();
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            var actualLoginFormText = Driver.FindElement(By.ClassName("logo-txt")).Text;

            Assert.AreEqual(expectedLoginFormText, actualLoginFormText);
        }
    }
}
