using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OddsGG_AccountMenuEditProfileTab
{
    public class OddsGGAccountMenuEditProfileTab
    {

        [FindsBy(How = How.Id, Using = "my-account-button")]
        public IWebElement AccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-info")]
        public IWebElement AccountNavigationMenuAccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "show-profile-tab")]
        public IWebElement AccountMenuViewProfileTab { get; set; }

        [FindsBy(How = How.Id, Using = "edit-profile-tab")]
        public IWebElement AccountMenuEditProfileTab { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement EditProfileCompanyNameField { get; set; }

        [FindsBy(How = How.Id, Using = "position")]
        public IWebElement EditProfilePositionField { get; set; }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement EditProfileContactNameField { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement EditProfileCountryField { get; set; }

        public string SelectedCountry { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EditProfileEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement EditProfileCityField { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement EditProfilePhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "purpose")]
        public IWebElement EditProfileUsagePurposeField { get; set; }

        [FindsBy(How = How.Id, Using = "website")]
        public IWebElement EditProfileWebsiteField { get; set; }

        [FindsBy(How = How.Id, Using = "skype-username")]
        public IWebElement EditProfileSkypeUsername { get; set; }

        [FindsBy(How = How.Id, Using = "update-button")]
        public IWebElement EditProfileUpdateProfileButton { get; set; }

        [FindsBy(How = How.Id, Using = "my-account-api-key")]
        public IWebElement AccountNavigationMenuApiKeyButton { get; set; }

        public void EditProfileCountryChange(string country)
        {
            SelectElement countryElement = new SelectElement(EditProfileCountryField);

            EditProfileCountryField.Click();

            countryElement.SelectByText(country);

            SelectedCountry = countryElement.SelectedOption.Text;
        }
    }
}
