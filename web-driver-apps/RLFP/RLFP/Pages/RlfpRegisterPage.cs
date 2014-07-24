using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RLFP.WebDriver;

namespace RLFP.Pages {
    public class RlfpRegisterPage : Page {

        public RlfpRegisterPage(IWebDriver driver)
            : base(driver, "/a/Public/Registration#AccountRegistration") {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            wait.Until(d => d.FindElement(By.Id("EmailAddress")));
        }

        public string EmailAddress {
            get { return Driver.GetInputElementText("EmailAddress"); }
            set { Driver.SetInputElementText("EmailAddress", value); }
        }

        public string ConfirmEmailAddress {
            get { return Driver.GetInputElementText("ConfirmEmailAddress"); }
            set { Driver.SetInputElementText("ConfirmEmailAddress", value); }
        }

        public string Password {
            get { return Driver.GetInputElementText("Password"); }
            set { Driver.SetInputElementText("Password", value); }
        }

        public bool TermsAndConditionsAccepted {
            get { return Driver.GetCheckboxState("TermsAndConditionAccepted_IsChecked"); }
            set { Driver.SetCheckboxState("TermsAndConditionAccepted_IsChecked", value); }
        }

        public bool PersistentLogin {
            get { return Driver.GetCheckboxState("IsLoginPersistent_IsChecked"); }
            set { Driver.SetCheckboxState("IsLoginPersistent_IsChecked", value); }
        }

        public RlfpFinancialFuturePage Submit() {
            return Driver.Submit<RlfpFinancialFuturePage>("wizardSubmitButton");
        }
    }
}