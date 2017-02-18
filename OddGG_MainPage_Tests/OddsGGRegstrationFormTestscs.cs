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

namespace OddGG_RegistrationForm_Tests
{
    [TestClass]
    public class OddsGGRegistrationFormTests : OddsGGBaseClass
    {

        public OddsGGRegistrationFormTests()
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

        [TestMethod]
        public void OpenRegistraionWindow()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("register-button")));

            string exptectedSignUpButtonText = "ODDS.GG";
            var actualSignupFormText = Driver.FindElement(By.ClassName("logo-txt")).Text;

            Assert.AreEqual(exptectedSignUpButtonText, actualSignupFormText);
        }

        [TestMethod]
        public void CloseRegistrationWindow()
        {
            MainPage.ClickOnSignUpButton();

            //Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("modal-content")));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("register-button")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("close-registration-modal-button")));

            RegistrationForm.CloseRegistrationForm();

            //vsichki formi da ne sa vidimi, clasa da e visible, register button to be visible
        }

        [TestMethod]
        public void RegistrationFormValidRegistration()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegisterAnAccount("dcrow@abv.bg", "qwerty", "qwerty");

            RegistrationForm.ClickOnRegisterButton();
        }

        [TestMethod]
        public void RegisterAnAccountWithAlreadyUsedEmail()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegisterAnAccount("dcrow@abv.bg", "qwerty", "qwerty");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedMessageIfAlreadyUsedMail = "User with that email already exists.";

            var actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedMessageIfAlreadyUsedMail, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormEmptyEmailFieldInput()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("");
            RegistrationForm.RegistrationFormPasswordField.SendKeys("qwerty");
            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("qwerty");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedTooShortPasswrdInput = "The Email field is required.";
            string actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedTooShortPasswrdInput, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormEmptyPasswordFieldInput()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("dcrow@abv.bg");
            RegistrationForm.RegistrationFormPasswordField.SendKeys("");
            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("qwerty");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedTooShortPasswrdInput = "The Password field is required.";
            string actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedTooShortPasswrdInput, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormTooShortPasswordFieldInput()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("dcrow@abv.bg");
            RegistrationForm.RegistrationFormPasswordField.SendKeys("qwert");
            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("qwerty");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedTooShortPasswrdInput = "Password must be at least 6 characters long.";
            string actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedTooShortPasswrdInput, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormEmptyConfirmationPasswordFieldInput()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("dcrow@abv.bg");
            RegistrationForm.RegistrationFormPasswordField.SendKeys("qwerty");
            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedTooShortPasswrdInput = "The Password confirmation field is required.";
            string actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedTooShortPasswrdInput, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormTooShortPasswordConfirmationFieldInput()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-modal")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("dcrow@abv.bg");
            RegistrationForm.RegistrationFormPasswordField.SendKeys("qwert");
            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("qwert");

            RegistrationForm.ClickOnRegisterButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registration-failure-error-message")));

            string expectedTooShortPasswrdInput = "Password must be at least 6 characters long.";
            string actualFormErrorMessage = RegistrationForm.RegistrationFormFieldErrorMessage.Text;

            Assert.AreEqual(expectedTooShortPasswrdInput, actualFormErrorMessage);
        }

        [TestMethod]
        public void RegistrationFormPasswordMatcher()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("modal-header")));

            RegistrationForm.RegistrationFormEmailField.SendKeys("dcrow@abv.bg");

            RegistrationForm.RegistrationFormPasswordField.SendKeys("123456");
            var pass = RegistrationForm.RegistrationFormPasswordField.GetAttribute("value");
            Console.WriteLine(pass);

            RegistrationForm.RegistrationFormPasswordConfirmationField.SendKeys("123456");
            var confirm = RegistrationForm.RegistrationFormPasswordConfirmationField.GetAttribute("value");
            Console.WriteLine(confirm);

            Assert.AreEqual(pass, confirm);
        }

        [TestMethod]
        public void RegistrationFormLoginHereButton()
        {
            MainPage.ClickOnSignUpButton();

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-link")));

            RegistrationForm.RegistrationFormLoginHereButton.Click();
        }
    }
}
