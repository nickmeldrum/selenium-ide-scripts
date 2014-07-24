using OpenQA.Selenium;
using RLFP.Model;
using RLFP.WebDriver;
using System;
using System.Globalization;

namespace RLFP.Pages {
    public class RlfpLoginPage : Page {
        public readonly BuildPlanPanel BuildPlanPanelForm;

        public RlfpLoginPage(IWebDriver driver)
            : base(driver, "/Login/?ReturnUrl=%2f") {
            BuildPlanPanelForm = new BuildPlanPanel(this);
        }

        public class BuildPlanPanel {
            private readonly RlfpLoginPage _parentPage;

            public string Name {
                get { return _parentPage.Driver.GetInputElementText("buildplan_name"); }
                set { _parentPage.Driver.SetInputElementText("buildplan_name", value); }
            }

            public Gender Gender {
                get {
                    if (_parentPage.Driver.GetRadioButtonState("buildplan_genderf")) return Gender.Female;
                    return _parentPage.Driver.GetRadioButtonState("buildplan_genderm") ? Gender.Male : Gender.NotSelected;
                }
                set {
                    switch (value) {
                        case Gender.Female:
                            _parentPage.Driver.SelectRadioButton("buildplan_genderf");
                            break;
                        case Gender.Male:
                            _parentPage.Driver.SelectRadioButton("buildplan_genderm");
                            break;
                    }
                }
            }

            public Month MonthOfBirth {
                get {
                    var value = _parentPage.Driver.GetSelectValue("buildplan_dobmonth");
                    if (string.IsNullOrWhiteSpace(value)) return Month.NotSelected;
                    return (Month)Enum.Parse(typeof(Month), value);
                }
                set {
                    if (value == Month.NotSelected) return;
                    _parentPage.Driver.SetSelectValue("buildplan_dobmonth", value.ToString());
                }
            }

            public int? YearOfBirth {
                get {
                    var value = _parentPage.Driver.GetSelectValue("buildplan_dobyear");
                    if (string.IsNullOrWhiteSpace(value)) return null;
                    return int.Parse(value);
                }
                set {
                    if (!value.HasValue) return;
                    _parentPage.Driver.SetSelectValue("buildplan_dobyear", value.Value.ToString(CultureInfo.InvariantCulture));
                }
            }

            public BuildPlanPanel(RlfpLoginPage parentPage) {
                _parentPage = parentPage;
            }

            public RlfpRegisterPage Submit() {
                return _parentPage.Driver.Submit<RlfpRegisterPage>("buildplan_button");
            }
        }
    }
}