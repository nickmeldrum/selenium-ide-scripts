using System;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RLFP.Model;

namespace RLFP.Pages {
    public class RlfpLoginPage {
        private readonly IWebDriver _driver;

        public RlfpLoginPage(IWebDriver driver) {
            _driver = driver;
        }

        public void Register(string name, Gender gender, DateTime monthOfBirth) {
            _driver.Url = "https://planner.royallondon.com/Login/?ReturnUrl=%2f";
            _driver.Navigate();

            var nameField = _driver.FindElement(By.Id("buildplan_name"));
            nameField.SendKeys(name);

            var maleGenderField = _driver.FindElement(By.Id("buildplan_genderm"));
            maleGenderField.Click();

            var monthField = _driver.FindElement(By.Id("buildplan_dobmonth"));
            var x = new SelectElement(monthField);
            x.SelectByText(monthOfBirth.ToString("MMMM", CultureInfo.InvariantCulture));

            var yearField = _driver.FindElement(By.Id("buildplan_dobyear"));
            var y = new SelectElement(yearField);
            y.SelectByText(monthOfBirth.Year.ToString(CultureInfo.InvariantCulture));

            var submitForm = _driver.FindElement(By.Id("buildplan_button"));
            submitForm.Click();
        }
    }
}