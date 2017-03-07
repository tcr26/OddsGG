using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddsGG_MainPage;

namespace OddsGG_BaseClass
{
    public abstract class OddsGGBaseClass
    {
        public OddsGGBaseClass()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            MainPage = new OddsGGMainPage();
            Driver.Navigate().GoToUrl(MainPage.url);
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected OddsGGMainPage MainPage { get; set; }
    }
}
