using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;
using OddsGG_LoginForm;
using OddsGG_BaseClass;
using OddsGG_AccountApiKeyMenu;

namespace OddGG_MainPage_Tests
{
    [TestClass]
    public class OddsGGAccountApiKeyMenuTests : OddsGGBaseClass
    {
        public OddsGGAccountApiKeyMenuTests()
        {
            LoginPage = new OddsGGLoginForm();
            AccountApiKeyMenu = new OddsGGAccountApiKeyMenu();
        }

        public OddsGGLoginForm LoginPage { get; set; }
        public OddsGGAccountApiKeyMenu AccountApiKeyMenu { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, LoginPage);
            PageFactory.InitElements(Driver, AccountApiKeyMenu);
        }

        [TestMethod]
        public void ProvideMoreInformationToGetApiKey()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.btn.se-btn-black.btn-rounded.main-btn.get-api-key-button")));

            AccountApiKeyMenu.GetApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("additionl-info-msg")));

            string expectedAccountButtonText = "To see your api key you have to provide additional information:";
            var actualAccountButtonText = Driver.FindElement(By.Id("additionl-info-msg")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void TooShortCompanyNameField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileCompanyNameField.Clear();
            AccountApiKeyMenu.EditProfileCompanyNameField.SendKeys("a");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("company-error")));

            string expectedErrorMessage = "Company must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("company-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortPositionField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfilePositionField.Clear();
            AccountApiKeyMenu.EditProfilePositionField.SendKeys("a");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("position-error")));

            string expectedErrorMessage = "Position must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("position-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortPersonNameField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileContactNameField.Clear();
            AccountApiKeyMenu.EditProfileContactNameField.SendKeys("a");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name-error")));

            string expectedErrorMessage = "Name must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("name-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void ChooseCountry()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            SelectElement countryToSelect = new SelectElement(AccountApiKeyMenu.EditProfileCountryField);

            AccountApiKeyMenu.EditProfileCountryChange("Bulgaria");

            var expectedSelectedCountry = countryToSelect.SelectedOption.Text;
            var actualSelectedCountry = AccountApiKeyMenu.SelectedCountry;

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Assert.AreEqual(expectedSelectedCountry, actualSelectedCountry);
        }

        [TestMethod]
        public void EmailFieldIsRequired()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileEmailField.Clear();
            AccountApiKeyMenu.EditProfileEmailField.SendKeys("");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email-error")));

            string expectedErrorMessage = "The Email field is required.";
            var actualErrorMessage = Driver.FindElement(By.Id("email-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortCityNameField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileCityField.Clear();
            AccountApiKeyMenu.EditProfileCityField.SendKeys("a");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("city-error")));

            string expectedErrorMessage = "City must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("city-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortPhoneNumberField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfilePhoneField.Clear();
            AccountApiKeyMenu.EditProfilePhoneField.SendKeys("1");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("phone-error")));

            string expectedErrorMessage = "Phone must be at least 6 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("phone-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void InvalidPhoneFieldInput()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfilePhoneField.Clear();
            AccountApiKeyMenu.EditProfilePhoneField.SendKeys("a1!");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("phone-error")));

            string expectedErrorMessage = "Use only numbers and + - ( ) signs.";
            var actualErrorMessage = Driver.FindElement(By.Id("phone-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortPurposeOfUsageField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileUsagePurposeField.Clear();
            AccountApiKeyMenu.EditProfileUsagePurposeField.SendKeys("asd");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("purpose-error")));

            string expectedErrorMessage = "Purpose of usage must be at least 4 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("purpose-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void TooShortWebsiteName()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountApiKeyMenu.EditProfileWebsiteField.Clear();
            AccountApiKeyMenu.EditProfileWebsiteField.SendKeys("a");

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("website-error")));

            string expectedErrorMessage = "Website must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("website-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void YourAccountApiKeyIs()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-api-key")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.text-bold")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("api-key-value")));

            string expectedAccountButtonText = "Your API key is:";
            var actualAccountButtonText = Driver.FindElement(By.CssSelector("h2.over-title.margin-bottom-0 span.text-bold")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void AccountInformationNeededForApiKey()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountApiKeyMenu.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("skype-username")));

            AccountApiKeyMenu.EditProfileSkypeUsername.Clear();

            AccountApiKeyMenu.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));

            AccountApiKeyMenu.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("additionl-info-msg")));

            string expectedAccountButtonText = "To see your api key you have to provide additional information:";
            var actualAccountButtonText = Driver.FindElement(By.Id("additionl-info-msg")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }
    }
}
