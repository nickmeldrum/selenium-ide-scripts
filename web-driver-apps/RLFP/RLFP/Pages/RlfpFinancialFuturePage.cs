using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RLFP.WebDriver;

namespace RLFP.Pages {
    public class RlfpFinancialFuturePage : Page {
        public RlfpFinancialFuturePage(IWebDriver driver)
            : base(driver, "/a/Public/Planning#FinancialFuture") {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(d => d.FindElement(By.Id("secure-login")));
        }

        public string WelcomeMessage {
            get {
                return Driver.FindElement(By.XPath("//div[@id='secure-login']/p/span")).Text;
            }
        }
    }
}