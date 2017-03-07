using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;
using OddsGG_RegistrationForm;
using OddsGG_BaseClass;

namespace OddGG_MainPage_Tests
{
    [TestClass]
    public class OddsGGMainPageTests : OddsGGBaseClass
    {

        public OddsGGMainPageTests()
        {
            RegistrationForm = new OddsGGRegistrationForm();
        }

        public OddsGGRegistrationForm RegistrationForm { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, RegistrationForm);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestMethod]
        public void ClickOnOddsGGLogo()
        {
            MainPage.LogoSign.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("logo-txt")));

            string expectedPageTitle = "ODDS.GG";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
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

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            var actualLoginFormText = Driver.FindElement(By.ClassName("logo-txt")).Text;

            Assert.AreEqual(expectedLoginFormText, actualLoginFormText);
        }
    }
}
