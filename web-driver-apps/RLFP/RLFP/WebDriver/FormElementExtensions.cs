using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RLFP.Pages;

namespace RLFP.WebDriver {
    public static class FormElementExtensions {
        public static void SetInputElementText(this IWebDriver driver, string elementId, string value)
        {
            var element = driver.FindElement(By.Id(elementId));
            element.Clear();
            element.SendKeys(value);
        }

        public static string GetInputElementText(this IWebDriver driver, string elementId) {
            var element = driver.FindElement(By.Id(elementId));
            return element.GetAttribute("value");
        }

        public static bool GetCheckboxState(this IWebDriver driver, string elementId) {
            var element = driver.FindElement(By.Id(elementId));
            return element.Selected;
        }

        public static void SetCheckboxState(this IWebDriver driver, string elementId, bool value) {
            var element = driver.FindElement(By.Id(elementId));

            if (value)
            {
                // then we want it set
                if (!element.Selected) element.Click();
            }
            else
            {
                if (element.Selected) element.Click();
            }
        }

        public static bool GetRadioButtonState(this IWebDriver driver, string elementId) {
            var element = driver.FindElement(By.Id(elementId));
            return element.Selected;
        }

        public static void SelectRadioButton(this IWebDriver driver, string elementId) {
            var element = driver.FindElement(By.Id(elementId));
            element.Click();
        }

        public static string GetSelectValue(this IWebDriver driver, string elementId) {
            var element = driver.FindElement(By.Id(elementId));
            var selectElement = new SelectElement(element);
            return selectElement.SelectedOption.GetAttribute("value");
        }

        public static void SetSelectValue(this IWebDriver driver, string elementId, string value) {
            var element = driver.FindElement(By.Id(elementId));
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public static T Submit<T>(this IWebDriver driver, string elementId) where T : Page
        {
            var submitForm = driver.FindElement(By.Id(elementId));
            submitForm.Click();

            return RlfpPageFactory.Get<T>(driver);
        }
    }
}
