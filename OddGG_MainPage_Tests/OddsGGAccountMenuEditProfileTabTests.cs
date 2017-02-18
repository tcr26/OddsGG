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
using OddsGG_AccountMenuEditProfileTab;

namespace OddGG_MainPage_Tests
{

    [TestClass]
    public class OddsGGAccountMenuEditProfileTabTests : OddsGGBaseClass
    {
        public OddsGGAccountMenuEditProfileTabTests()
        {
            LoginPage = new OddsGGLoginForm();
            AccountMenuProfileTab = new OddsGGAccountMenuEditProfileTab();
        }

        public OddsGGLoginForm LoginPage { get; set; }

        public OddsGGAccountMenuEditProfileTab AccountMenuProfileTab { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, LoginPage);
            PageFactory.InitElements(Driver, AccountMenuProfileTab);
        }

        [TestMethod]
        public void ClickOnEditProfileTabInAccountMenu()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-info")));

            AccountMenuProfileTab.AccountNavigationMenuAccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            string expectedAccountButtonText = "Edit Profile";
            var actualAccountButtonText = AccountMenuProfileTab.AccountMenuEditProfileTab.Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void ChangeAccountInfoThroughEditProfileTab()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileCompanyNameField.Clear();
            AccountMenuProfileTab.EditProfileCompanyNameField.SendKeys("Crow Inc.");

            AccountMenuProfileTab.EditProfilePositionField.Clear();
            AccountMenuProfileTab.EditProfilePositionField.SendKeys("Unknown");

            AccountMenuProfileTab.EditProfileContactNameField.Clear();
            AccountMenuProfileTab.EditProfileContactNameField.SendKeys("Unknown");

            AccountMenuProfileTab.EditProfileCountryChange("Bulgaria");

            AccountMenuProfileTab.EditProfileCityField.Clear();
            AccountMenuProfileTab.EditProfileCityField.SendKeys("Varna");

            AccountMenuProfileTab.EditProfilePhoneField.Clear();
            AccountMenuProfileTab.EditProfilePhoneField.SendKeys("+35912345678");

            AccountMenuProfileTab.EditProfileUsagePurposeField.Clear();
            AccountMenuProfileTab.EditProfileUsagePurposeField.SendKeys("Unknown");

            AccountMenuProfileTab.EditProfileWebsiteField.Clear();
            AccountMenuProfileTab.EditProfileWebsiteField.SendKeys("www.asd.bg");

            AccountMenuProfileTab.EditProfileSkypeUsername.Clear();
            AccountMenuProfileTab.EditProfileSkypeUsername.SendKeys("Unknown");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-api-key")));

            AccountMenuProfileTab.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.text-bold")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("api-key-value")));

            string expectedMessage = "Your API key is:";
            var actualMessage = Driver.FindElement(By.CssSelector("h2.over-title.margin-bottom-0 span.text-bold")).Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void TooShortCompanyNameField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileCompanyNameField.Clear();
            AccountMenuProfileTab.EditProfileCompanyNameField.SendKeys("a");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfilePositionField.Clear();
            AccountMenuProfileTab.EditProfilePositionField.SendKeys("a");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileContactNameField.Clear();
            AccountMenuProfileTab.EditProfileContactNameField.SendKeys("a");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            SelectElement countryToSelect = new SelectElement(AccountMenuProfileTab.EditProfileCountryField);

            AccountMenuProfileTab.EditProfileCountryChange("Bulgaria");

            var expectedSelectedCountry = countryToSelect.SelectedOption.Text;
            var actualSelectedCountry = AccountMenuProfileTab.SelectedCountry;

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileEmailField.Clear();

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileCityField.Clear();
            AccountMenuProfileTab.EditProfileCityField.SendKeys("a");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfilePhoneField.Clear();
            AccountMenuProfileTab.EditProfilePhoneField.SendKeys("1");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfilePhoneField.Clear();
            AccountMenuProfileTab.EditProfilePhoneField.SendKeys("a1!");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileUsagePurposeField.Clear();
            AccountMenuProfileTab.EditProfileUsagePurposeField.SendKeys("asd");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

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

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileWebsiteField.Clear();
            AccountMenuProfileTab.EditProfileWebsiteField.SendKeys("a");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("website-error")));

            string expectedErrorMessage = "Website must be at least 3 characters long.";
            var actualErrorMessage = Driver.FindElement(By.Id("website-error")).Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestMethod]
        public void SkypeUserNameField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            AccountMenuProfileTab.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            AccountMenuProfileTab.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            AccountMenuProfileTab.EditProfileSkypeUsername.Clear();
            AccountMenuProfileTab.EditProfileSkypeUsername.SendKeys("asd");

            var expectedErrorMessage = AccountMenuProfileTab.EditProfileSkypeUsername.GetAttribute("value");

            AccountMenuProfileTab.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile")));

            if (Driver.FindElement(By.Id("show-profile-tab")).Displayed)
            {
                var actualErrorMessage = Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div/div/div/table[1]/tbody/tr[5]/td[2]")).Text;

                Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            }
        }
    }
}
