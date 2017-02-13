using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OddsGG_Account
{
    public class OddsGGAccount
    {
        public string url = "https://odds.gg/";

        [FindsBy(How = How.Id, Using = "logo-txt")]
        public IWebElement LogoSign { get; set; }

        [FindsBy(How = How.Id, Using = "what-we-offer-button")]
        public IWebElement WhatWeOfferButton { get; set; }

        [FindsBy(How = How.Id, Using = "who-are-we-button")]
        public IWebElement WhoAreWeButton { get; set; }

        [FindsBy(How = How.Id, Using = "api-docs-button")]
        public IWebElement ApiDocsButton { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-button")]
        public IWebElement AccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "logout-button")]
        public IWebElement AccountLogoutButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.btn.se-btn-black.btn-rounded.main-btn.get-api-key-button")]
        public IWebElement GetApiKeyButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        public IWebElement AccountSettingOddsGgLogoSign { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.navbar-brand.navbar-brand-collapsed")]
        public IWebElement AccountSettingCollapsedOddsGgLogoSign { get; set; }

        [FindsBy(How = How.Id, Using = "sidebar-toggler")]
        public IWebElement AccountSideBarButton { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-logout-button")]
        public IWebElement AccountLogoutButtonInAccountSettings { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-info")]
        public IWebElement AccountNavigationMenuAccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "show-profile-tab")]
        public IWebElement AccountMenuViewProfileTab { get; set; }

        [FindsBy(How = How.Id, Using = "edit-profile-tab")]
        public IWebElement AccountMenuEditProfileTab { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement EditProfileCompanyNameField { get; set; }

        [FindsBy(How = How.Id, Using = "company-error")]
        public IWebElement CompanyNameErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "position")]
        public IWebElement EditProfilePositionField { get; set; }

        [FindsBy(How = How.Id, Using = "position-error")]
        public IWebElement PositionFieldErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement EditProfileContactNameField { get; set; }

        [FindsBy(How = How.Id, Using = "name-error")]
        public IWebElement ContactNameErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement EditProfileCountryField { get; set; }

        public string SelectedCountry { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EditProfileEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "email-error")]
        public IWebElement EmailErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement EditProfileCityField { get; set; }

        [FindsBy(How = How.Id, Using = "city-error")]
        public IWebElement CityErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement EditProfilePhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "phone-error")]
        public IWebElement PhoneErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "purpose")]
        public IWebElement EditProfileUsagePurposeField { get; set; }

        [FindsBy(How = How.Id, Using = "purpose-error")]
        public IWebElement PurposeOfUsageErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "website")]
        public IWebElement EditProfileWebsiteField { get; set; }

        [FindsBy(How = How.Id, Using = "website-error")]
        public IWebElement WebSiteErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "skype-username")]
        public IWebElement EditProfileSkypeUsername { get; set; }

        [FindsBy(How = How.Id, Using = "update-button")]
        public IWebElement EditProfileUpdateProfileButton { get; set; }

        [FindsBy(How = How.Id, Using = "change-password-tab")]
        public IWebElement AccountMenuChangePasswordTab { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-api-key")]
        public IWebElement AccountNavigationMenuApiKeyButton { get; set; }

        [FindsBy(How = How.Id, Using = "api-key-value")]
        public IWebElement MyAccountApiKey { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-docs")]
        public IWebElement AccountNavigationMenuDocsButton { get; set; }

        public void EditProfileCountryChange(string country)
        {
            SelectElement countryElement = new SelectElement(EditProfileCountryField);

            EditProfileCountryField.Click();

            countryElement.SelectByText(country);

            SelectedCountry = countryElement.SelectedOption.Text;
        }
    }
}
