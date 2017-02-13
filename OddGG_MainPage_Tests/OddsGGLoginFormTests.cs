using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;
using OddsGG_LoginForm;

namespace OddGG_LoginForm_Tests
{
    [TestClass]
    public class OddsGGLoginFormTests
    {

        public OddsGGLoginFormTests()
        {
            Driver = new FirefoxDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            MainPage = new OddsGGMainPage();
            LoginForm = new OddsGGLoginForm();
        }

        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public OddsGGMainPage MainPage { get; set; }
        public OddsGGLoginForm LoginForm { get; set; }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, MainPage);
            PageFactory.InitElements(Driver, LoginForm);
            Driver.Navigate().GoToUrl(MainPage.url);
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void OpenLoginForm()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            string exptectedLoginButtonText = "LOGIN";
            var actualLoginFormText = LoginForm.LoginFormLoginButton.GetAttribute("value");

            Assert.AreEqual(exptectedLoginButtonText, actualLoginFormText);
        }

        [TestMethod]
        public void CloseLoginForm()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("close-login-modal-button")));

            LoginForm.CloseLoginForm();
        }

        [TestMethod]
        public void LoginFormLoginToOddsGG()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginForm.LoginToOddsGgAccount("dcrow@abv.bg", "qwerty");

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout-button")));

            string expectedLogoutButtonText = "LOGOUT";
            var actualLogoutButtonTest = Driver.FindElement(By.Id("logout-button")).Text;

            Assert.AreEqual(expectedLogoutButtonText, actualLogoutButtonTest);
        }

        [TestMethod]
        public void LoginFormLoginWithEmptyEmailField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            LoginForm.ClickOnLoginButtonInLoginForm();

            var expectedEmailErrorMessage = "The Email field is required.";
            var actualEmailErrorMessage = LoginForm.LoginFormEmailErrorMessage.Text;

            Assert.AreEqual(expectedEmailErrorMessage, actualEmailErrorMessage);
        }

        [TestMethod]
        public void LoginFormLoginWithEmptyPasswordField()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            LoginForm.LoginFormLoginButton.Click();

            string expectedPaswordErrorMessage = "The Password field is required.";
            var actualPasswordErrorMessage = LoginForm.LoginFormPasswordErrorMessage.Text;

            Assert.AreEqual(expectedPaswordErrorMessage, actualPasswordErrorMessage);
        }

        [TestMethod]
        public void LoginFormInvalidEmailInput()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            LoginForm.LoginFormEmailField.SendKeys("1@com");
            LoginForm.LoginFormPasswordField.SendKeys("qwerty");

            LoginForm.ClickOnLoginButtonInLoginForm();

            string expectedIfEmailIsInvalid = "The Email field is not a valid e-mail address.";
            var actualEmailErrorMessage = LoginForm.LoginFormEmailErrorMessage.Text;

            Assert.AreEqual(expectedIfEmailIsInvalid, actualEmailErrorMessage);
        }

        [TestMethod]
        public void LoginFormTooShortPasswordInput()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            LoginForm.LoginFormEmailField.SendKeys("asd@qaz.bg");
            LoginForm.LoginFormPasswordField.SendKeys("qwert");

            LoginForm.ClickOnLoginButtonInLoginForm();

            string expectedIfPasswordIsTooShort = "Password must be at least 6 characters.";
            var actualPasswordErrorMessage = LoginForm.LoginFormPasswordErrorMessage.Text;

            Assert.AreEqual(expectedIfPasswordIsTooShort, actualPasswordErrorMessage);
        }

        [TestMethod]
        public void LoginFormInvalidLoginCredentials()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));

            LoginForm.LoginFormEmailField.SendKeys("asd@qaz.bg");
            LoginForm.LoginFormPasswordField.SendKeys("qwerty");

            LoginForm.ClickOnLoginButtonInLoginForm();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("error-message-container")));

            var invalidLoginCredentials = Driver.FindElement(By.CssSelector("p#login-fail-message.bg-danger span")).Text;

            string expectedIfPasswordIsTooShort = "INVALID LOGIN CREDENTIALS";
            var actualEmailErrorMessage = LoginForm.LoginInvalidLoginCredentials.Text;

            Assert.AreEqual(expectedIfPasswordIsTooShort, actualEmailErrorMessage);
        }

        [TestMethod]
        public void LoginFormForgottenPassword()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginForm.LoginFormForgottenPasswordButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));

            LoginForm.LoginFormForgottenPasswordRestoreOnEmail.SendKeys("dcrow@abv.bg");
            LoginForm.LoginFormRestorePasswordButton.Click();
        }

        [TestMethod]
        public void LoginFormClickOnJoinNowButton()
        {
            MainPage.ClickOnLoginButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("back-to-registration-button")));

            LoginForm.LoginFormJoinNowButton.Click();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            var signUpElementText = Driver.FindElement(By.Id("register-button")).GetAttribute("value");

            string expectedSignUpFormMessage = "Register";
            string actualSignUpFormMessage = signUpElementText;

            Assert.AreEqual(expectedSignUpFormMessage, actualSignUpFormMessage);
        }
    }
}
