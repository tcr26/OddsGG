using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;
using OddsGG_LoginForm;
using OddsGG_Account;

namespace OddGG_Account_Tests
{
    [TestClass]
    public class OddsGGAccountTests
    {

        public OddsGGAccountTests()
        {
            Driver = new FirefoxDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            MainPage = new OddsGGMainPage();
            LoginPage = new OddsGGLoginForm();
            Account = new OddsGGAccount();
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public OddsGGMainPage MainPage { get; set; }
        public OddsGGLoginForm LoginPage { get; set; }
        public OddsGGAccount Account { get; set; }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, LoginPage);
            PageFactory.InitElements(Driver, Account);
            Driver.Navigate().GoToUrl(MainPage.url);
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void AccountLoginToOddsGg()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout-button")));

            string expectedLogoutButtonText = "LOGOUT";
            var actualLogoutButtonTest = Driver.FindElement(By.Id("logout-button")).Text;

            Assert.AreEqual(expectedLogoutButtonText, actualLogoutButtonTest);
        }

        [TestMethod]
        public void AccountLogoutFromOddsGgAccount()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout-button")));

            Account.AccountLogoutButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button-header")));

            string expectedTextAfterLogout = "LOGIN";
            var actualTextAfterLogout = MainPage.LoginButton.Text;

            Assert.AreEqual(expectedTextAfterLogout, actualTextAfterLogout);
        }

        [TestMethod]
        public void AccountClickOnAccountButton()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.TitleIs("Odds.gg account settings"));

            string expectedPageTitle = "Odds.gg account settings";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [TestMethod]
        public void ClickOnGetApiKeyButton()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.btn.se-btn-black.btn-rounded.main-btn.get-api-key-button")));

            Account.GetApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span.text-bold")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("api-key-value")));

            string expectedAccountButtonText = "Your API key is:";
            var actualAccountButtonText = Driver.FindElement(By.CssSelector("h2.over-title.margin-bottom-0 span.text-bold")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void ProvideMoreInformationToGetApiKey()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.btn.se-btn-black.btn-rounded.main-btn.get-api-key-button")));

            Account.GetApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("additionl-info-msg")));

            string expectedAccountButtonText = "To see your api key you have to provide additional information:";
            var actualAccountButtonText = Driver.FindElement(By.Id("additionl-info-msg")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void ClickOnOddsGgLogoSignInAccountSettings()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("navbar-brand")));

            Account.AccountSettingOddsGgLogoSign.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout-button")));

            string expectedPageTitle = "ODDS.GG";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [TestMethod]
        public void ClickOnCollapsedOddsGgLogoSignInAccountSetting()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sidebar-toggler")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("sidebar-toggler")));

            Account.AccountSideBarButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a.navbar-brand.navbar-brand-collapsed")));

            Account.AccountSettingCollapsedOddsGgLogoSign.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout-button")));

            string expectedPageTitle = "ODDS.GG";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [TestMethod]
        public void ClickOnSidebarMenuButtonInAccountSettings()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sidebar-toggler")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("sidebar-toggler")));

            Account.AccountSideBarButton.Click();

            bool isTheElementDisplayer = Driver.FindElement(By.CssSelector("div.navbar-title span")).Displayed;

            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.navbar-brand.navbar-brand-collapsed")));

            Assert.IsFalse(isTheElementDisplayer);
        }

        [TestMethod]
        public void LogoutFromAccountSettingsMenu()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-logout-button")));

            Account.AccountLogoutButtonInAccountSettings.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button-header")));

            string expectedTextAfterLogout = "LOGIN";
            var actualTextAfterLogout = MainPage.LoginButton.Text;

            Assert.AreEqual(expectedTextAfterLogout, actualTextAfterLogout);
        }

        [TestMethod]
        public void ClickOnAccountTabInAccountSettings()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-info")));

            Account.AccountNavigationMenuAccountButton.Click();

            string expectedAccountButtonText = "View Profile";
            var actualAccountButtonText = Account.AccountMenuViewProfileTab.Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void ClickOnEditProfileTabInAccountMenu()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-info")));

            Account.AccountNavigationMenuAccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            string expectedAccountButtonText = "Edit Profile";
            var actualAccountButtonText = Account.AccountMenuEditProfileTab.Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void ChangeAccountInfoThroughEditProfileTab()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileCompanyNameField.Clear();
            Account.EditProfileCompanyNameField.SendKeys("Crow Inc.");

            Account.EditProfilePositionField.Clear();
            Account.EditProfilePositionField.SendKeys("Unknown");

            Account.EditProfileContactNameField.Clear();
            Account.EditProfileContactNameField.SendKeys("Unknown");

            Account.EditProfileCountryChange("Bulgaria");

            Account.EditProfileCityField.Clear();
            Account.EditProfileCityField.SendKeys("Varna");

            Account.EditProfilePhoneField.Clear();
            Account.EditProfilePhoneField.SendKeys("+35912345678");

            Account.EditProfileUsagePurposeField.Clear();
            Account.EditProfileUsagePurposeField.SendKeys("Unknown");

            Account.EditProfileWebsiteField.Clear();
            Account.EditProfileWebsiteField.SendKeys("www.asd.bg");

            Account.EditProfileSkypeUsername.Clear();
            Account.EditProfileSkypeUsername.SendKeys("Unknown");

            Account.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-api-key")));

            Account.AccountNavigationMenuApiKeyButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileCompanyNameField.Clear();
            Account.EditProfileCompanyNameField.SendKeys("a");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfilePositionField.Clear();
            Account.EditProfilePositionField.SendKeys("a");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileContactNameField.Clear();
            Account.EditProfileContactNameField.SendKeys("a");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            SelectElement countryToSelect = new SelectElement(Account.EditProfileCountryField);

            Account.EditProfileCountryChange("Bulgaria");

            var expectedSelectedCountry = countryToSelect.SelectedOption.Text;
            var actualSelectedCountry = Account.SelectedCountry;

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileEmailField.Clear();
            Account.EditProfileEmailField.SendKeys("");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileCityField.Clear();
            Account.EditProfileCityField.SendKeys("a");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfilePhoneField.Clear();
            Account.EditProfilePhoneField.SendKeys("1");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfilePhoneField.Clear();
            Account.EditProfilePhoneField.SendKeys("a1!");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileUsagePurposeField.Clear();
            Account.EditProfileUsagePurposeField.SendKeys("asd");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileWebsiteField.Clear();
            Account.EditProfileWebsiteField.SendKeys("a");

            Account.EditProfileUpdateProfileButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit")));

            Account.EditProfileSkypeUsername.Clear();
            Account.EditProfileSkypeUsername.SendKeys("asd");

            var expectedErrorMessage = Account.EditProfileSkypeUsername.GetAttribute("value");

            Account.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("show-profile-tab")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile")));

            if (Driver.FindElement(By.Id("show-profile-tab")).Displayed)
            {
                var actualErrorMessage = Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div/div/div/table[1]/tbody/tr[5]/td[2]")).Text;

                Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
            }
        }

        [TestMethod]
        public void ClickOnChangePasswordTabInAccountMenu()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-info")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-info")));

            Account.AccountNavigationMenuAccountButton.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("change-password-tab")));

            Account.AccountMenuChangePasswordTab.Click();

            string expectedAccountButtonText = "Change Password";
            var actualAccountButtonText = Account.AccountMenuChangePasswordTab.Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }

        [TestMethod]
        public void YourAccountApiKeyIs()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginPage.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-button")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-button")));

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("my-account-api-key")));

            Account.AccountNavigationMenuApiKeyButton.Click();

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

            Account.AccountButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("edit-profile-tab")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("edit-profile-tab")));

            Account.AccountMenuEditProfileTab.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("skype-username")));

            Account.EditProfileSkypeUsername.Clear();

            Account.EditProfileUpdateProfileButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("my-account-api-key")));

            Account.AccountNavigationMenuApiKeyButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("additionl-info-msg")));

            string expectedAccountButtonText = "To see your api key you have to provide additional information:";
            var actualAccountButtonText = Driver.FindElement(By.Id("additionl-info-msg")).Text;

            Assert.AreEqual(expectedAccountButtonText, actualAccountButtonText);
        }
    }
}