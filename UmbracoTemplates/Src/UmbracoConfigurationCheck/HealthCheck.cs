// https://our.umbraco.com/documentation/Extending/Health-Check/
// https://our.umbraco.com/documentation/Extending/Health-Check/#configuration-checks

using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Services;

namespace $webnamespace$

        //Replace here the GUID, name, description and group of your health check
        [HealthCheck ("D0F7599E-9B2A-4D9E-9883-81C7EDC5616F", "$fileinputname$",
            Description = "Checks to make sure macro errors are not set to throw a YSOD (yellow screen of death), which would prevent certain or all pages from loading completely.",
            Group = "Configuration")]
        public class $safeitemname$ : AbstractConfigCheck {
        private readonly ILocalizedTextService _textService;

        // Use the built-in Umbraco DI container to bring any dependencies you need
        public $safeitemname$ (HealthCheckContext healthCheckContext) : base (healthCheckContext) {
            _textService = healthCheckContext.ApplicationContext.Services.TextService;
        }

        // FilePath is the relative path to which config file you want to check
        public override string FilePath {
            get { return "~/Config/umbracoSettings.config"; }
        }

        //XPath is the query you want to execute to find the configuration value you want to verify
        public override string XPath {
            get { return "/settings/content/MacroErrors"; }
        }

        // ValueComparisonType can either be ValueComparisonType.ShouldEqual or ValueComparisonType.ShouldNotEqual
        public override ValueComparisonType ValueComparisonType {
            get { return ValueComparisonType.ShouldEqual; }
        }

        // Values is a list of values that are available for this configuration item
        public override IEnumerable<AcceptableConfiguration> Values {
            get {
                var values = new List<AcceptableConfiguration> {
                    new AcceptableConfiguration {
                    IsRecommended = true,
                    Value = "inline"
                    },
                    new AcceptableConfiguration {
                    IsRecommended = false,
                    Value = "silent"
                    }
                };

                return values;
            }
        }

        // CheckSuccessMessage, CheckErrorMessage and RectifySuccessMessage are the messages returned to the user
        
        public override string CheckSuccessMessage {
            get {
                return _textService.Localize ("healthcheck/macroErrorModeCheckSuccessMessage",
                    new [] { CurrentValue, Values.First (v => v.IsRecommended).Value });
            }
        }

        public override string CheckErrorMessage {
            get {
                return _textService.Localize ("healthcheck/macroErrorModeCheckErrorMessage",
                    new [] { CurrentValue, Values.First (v => v.IsRecommended).Value });
            }
        }

        public override string RectifySuccessMessage {
            get {
                return _textService.Localize ("healthcheck/macroErrorModeCheckRectifySuccessMessage",
                    new [] { Values.First (v => v.IsRecommended).Value });
            }
        }
    }
}