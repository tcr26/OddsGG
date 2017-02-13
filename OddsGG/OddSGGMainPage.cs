using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OddsGG_MainPage
{
    public class OddsGGMainPage
    {
        public string url = "https://odds.gg/";

        [FindsBy(How = How.ClassName, Using = "logo-txt")]
        public IWebElement LogoSign { get; set; }

        [FindsBy(How = How.Id, Using = "what-we-offer-button")]
        public IWebElement WhatWeOfferButton { get; set; }

        [FindsBy(How = How.Id, Using = "who-are-we-button")]
        public IWebElement WhoWeAreButton { get; set; }

        [FindsBy(How = How.Id, Using = "api-docs-header-button")]
        public IWebElement ApiDocsButton { get; set; }

        [FindsBy(How = How.Id, Using = "register-button-modal")]
        public IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.Id, Using = "registration-modal")]
        public IWebElement SignUpForm { get; set; }

        [FindsBy(How = How.Id, Using = "login-button-header")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "login-modal")]
        public IWebElement LoginForm { get; set; }

        [FindsBy(How = How.Id, Using = "get-api-key-top")]
        public IWebElement GetApiKeyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "mo")]
        public IWebElement FeedByTheNumbers { get; set; }

        public void ClickOnOddsGGLogoButton()
        {
            LogoSign.Click();
        }

        public void ClickOnWhatWeOfferButton()
        {
            WhatWeOfferButton.Click();
        }

        public void ClickOnWhoWeAreButton()
        {
            WhoWeAreButton.Click();
        }

        public void ClickOnApiDocsButton()
        {
            ApiDocsButton.Click();
        }

        public void ClickOnSignUpButton()
        {
            SignUpButton.Click();
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickOnGetApiKeyButton()
        {
            GetApiKeyButton.Click();
        }
    }
}
