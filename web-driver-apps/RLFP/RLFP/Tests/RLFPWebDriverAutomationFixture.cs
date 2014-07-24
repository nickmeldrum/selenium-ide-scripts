using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using RLFP.Model;
using RLFP.Pages;
using RLFP.WebDriver;

namespace RLFP.Tests {
    [TestFixture]
    public class RlfpWebDriverAutomationFixture {
        [Test]
        public void RlfpAutomation_When_RegisterAndAddIncome_Then_WeHaveAChartWithIncomeOnIt()
        {
            var name = "WebDriverTester";
            var emailAddress = string.Format("WebDriverTester+{0}@nickmeldrum.com", Guid.NewGuid());

            using (var browser = new ChromeDriver()) {

                // arrange
                var loginPage = RlfpPageFactory.Get<RlfpLoginPage>(browser);
                loginPage.Browse();

                // act
                loginPage.BuildPlanPanelForm.Name = name;
                loginPage.BuildPlanPanelForm.Gender = Gender.Male;
                loginPage.BuildPlanPanelForm.MonthOfBirth = Month.January;
                loginPage.BuildPlanPanelForm.YearOfBirth = 1980;

                var registerPage = loginPage.BuildPlanPanelForm.Submit();

                registerPage.EmailAddress = emailAddress;
                registerPage.ConfirmEmailAddress = emailAddress;
                registerPage.Password = "password";
                registerPage.TermsAndConditionsAccepted = true;

                var financialFuturePage = registerPage.Submit();

                // assert
                Assert.That(financialFuturePage.WelcomeMessage.ToLower(CultureInfo.InvariantCulture),
                    Is.EqualTo(string.Format("Welcome {0}", name).ToLower(CultureInfo.InvariantCulture)));

                browser.Quit();
            }
        }
    }
}