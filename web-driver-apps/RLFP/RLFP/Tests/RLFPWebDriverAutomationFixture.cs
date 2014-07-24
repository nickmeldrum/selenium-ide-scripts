using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using RLFP.Model;
using RLFP.Pages;

namespace RLFP.Tests {
    [TestFixture]
    public class RlfpWebDriverAutomationFixture {
        [Test]
        public void RlfpAutomation_When_RegisterAndAddIncome_Then_WeHaveAChartWithIncomeOnIt() {
            // arrange
            using (var browser = new ChromeDriver()) {
                var rlfpLoginPage = new RlfpLoginPage(browser);

                // act
                rlfpLoginPage.Register("WebDriverTester", Gender.Male, DateTime.Now.AddYears(-25));
            }

            // assert
            Assert.That(false, Is.True);
        }
    }
}