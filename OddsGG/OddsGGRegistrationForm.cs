using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OddsGG_RegistrationForm
{
    public class OddsGGRegistrationForm
    {
        public string url = "https://odds.gg/";

        [FindsBy(How = How.ClassName, Using = "modal-header")]
        public IWebElement RegistrationFormWindowOpened { get; set; }

        [FindsBy(How = How.Id, Using = "close-registration-modal-button")]
        public IWebElement CloseRegistrationFormWindow { get; set; }

        [FindsBy(How = How.Id, Using = "registration-modal")]
        public IWebElement SignUpForm { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement RegistrationFormEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement RegistrationFormPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        public IWebElement RegistrationFormPasswordConfirmationField { get; set; }

        [FindsBy(How = How.Id, Using = "register-button")]
        public IWebElement RegistrationFormRegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "login-link")]
        public IWebElement RegistrationFormLoginHereButton { get; set; }

        [FindsBy(How = How.Id, Using = "registration-failure-error-message")]
        public IWebElement RegistrationFormFieldErrorMessage { get; set; }

        public void OpenRegistraionForm()
        {
            RegistrationFormWindowOpened.Click();
        }

        public void CloseRegistrationForm()
        {
            CloseRegistrationFormWindow.Click();
        }

        public void RegisterAnAccount(string email, string password, string confirmPassword)
        {
            RegistrationFormEmailField.SendKeys(email);
            RegistrationFormPasswordField.SendKeys(password);
            RegistrationFormPasswordConfirmationField.SendKeys(confirmPassword);
        }

        public void ClickOnRegisterButton()
        {
            RegistrationFormRegisterButton.Click();
        }
    }
}
