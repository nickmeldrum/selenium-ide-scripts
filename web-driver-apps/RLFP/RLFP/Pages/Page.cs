using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RLFP.Pages {
    public abstract class Page
    {
        private readonly string baseUrl = "https://planner.royallondon.com";
        public string Url { get; private set; }

        protected readonly IWebDriver Driver;

        protected Page(IWebDriver driver, string url) {
            Driver = driver;
            Url = baseUrl + url; 

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void Browse() {
            Driver.Url = Url;
        }
    }
}