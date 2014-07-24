using System;
using OpenQA.Selenium;
using RLFP.Pages;

namespace RLFP.WebDriver
{
    public static class RlfpPageFactory
    {
        public static T Get<T>(IWebDriver driver) where T : Page
        {
            return (T)Activator.CreateInstance(typeof(T), driver);
        }
    }
}