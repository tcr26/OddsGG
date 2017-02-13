using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OddsGG_LoginForm
{
    public class OddsGGLoginForm
    {
        public string url = "https://odds.gg/";

        [FindsBy(How = How.ClassName, Using = "modal-content")]
        public IWebElement LoginForm { get; set; }

        [FindsBy(How = How.Id, Using = "close-login-modal-button")]
        public IWebElement CloseRegistrationFormWindow { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div[2]/div/div/form[1]/div[1]/input")]
        public IWebElement LoginFormEmailField { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div[2]/div/div/form[1]/div[1]/span/span")]
        public IWebElement LoginFormEmailErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div[2]/div/div/form[1]/div[2]/input")]
        public IWebElement LoginFormPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div[2]/div/div/form[1]/div[2]/span/span")]
        public IWebElement LoginFormPasswordErrorMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "p#login-fail-message.bg-danger span")]
        public IWebElement LoginInvalidLoginCredentials { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement LoginFormLoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "back-to-registration-button")]
        public IWebElement LoginFormJoinNowButton { get; set; }

        [FindsBy(How = How.Id, Using = "forgot-pass-button")]
        public IWebElement LoginFormForgottenPasswordButton { get; set; }

        [FindsBy(How = How.Id, Using = "email-input")]
        public IWebElement LoginFormForgottenPasswordRestoreOnEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn.btn-default")]
        public IWebElement LoginFormRestorePasswordButton { get; set; }

        public void ClickOnLoginButtonInLoginForm()
        {
            LoginFormLoginButton.Click();
        }

        public void CloseLoginForm()
        {
            CloseRegistrationFormWindow.Click();
        }

        public void LoginToOddsGgAccount(string email, string password)
        {
            LoginFormEmailField.SendKeys(email);
            LoginFormPasswordField.SendKeys(password);
            LoginFormLoginButton.Click();
        }
    }
}
