// https://our.umbraco.com/documentation/Extending/Health-Check/
// https://our.umbraco.com/Documentation/Extending/Health-Check/#custom-health-check-notifications

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;

namespace $rootnamespace$ {

        //Replace here the GUID, name, description and group of your health check
        [HealthCheck ("3A482719-3D90-4BC1-B9F8-910CD9CF5B32", "$fileinputname$",
            Description = "Create a robots.txt file to block access to system folders.",
            Group = "SEO")]
        public class $safeitemname$ : HealthCheck {
        
            private readonly ILocalizedTextService _textService;
            private readonly ILogger _logger;

            public HealthCheck1(ILocalizedTextService textService, ILogger logger) : base()
            {
                _textService = textService;
                _logger = logger;
            }


// You can return multiple status checks from GetStatus()
public override IEnumerable GetStatus () {
            return new [] { CheckForRobotsTxtFile () };
        }

        public override HealthCheckStatus ExecuteAction (HealthCheckAction action) {
            switch (action.Alias) {
                case "addDefaultRobotsTxtFile":
                    return AddDefaultRobotsTxtFile ();
                default:
                    throw new ArgumentOutOfRangeException ();
            }
        }

        private HealthCheckStatus CheckForRobotsTxtFile () {
            var success = File.Exists (HttpContext.Current.Server.MapPath ("~/robots.txt"));
            var message = success ?
                _textService.Localize ("healthcheck/seoRobotsCheckSuccess") :
                _textService.Localize ("healthcheck/seoRobotsCheckFailed");

            var actions = new List<HealthCheckAction>();

            if (success == false)
                //A HealthCheckAction needs to provide an alias for an action that can be picked up in the ExecuteAction method
                actions.Add (new HealthCheckAction ("addDefaultRobotsTxtFile", Id)
                    // Override the "Rectify" button name and describe what this action will do
                    {
                        Name = _textService.Localize ("healthcheck/seoRobotsRectifyButtonName"),
                            Description = _textService.Localize ("healthcheck/seoRobotsRectifyDescription")
                    });

            return
            new HealthCheckStatus (message) {
                ResultType = success ? StatusResultType.Success : StatusResultType.Error,
                    Actions = actions
            };
        }

        private HealthCheckStatus AddDefaultRobotsTxtFile () {
            var success = false;
            var message = string.Empty;
            const string content = @"# robots.txt for Umbraco
                                    User-agent: *
                                    Disallow: /umbraco/";

            try {
                File.WriteAllText (HostingEnvironment.MapPath ("~/robots.txt"), content);
                success = true;
            } catch (Exception exception) {
                _logger.Error<$safeitemname$> (exception, "Could not write robots.txt to the root of the site");

            }

    return
            new HealthCheckStatus (message) {
                ResultType = success ? StatusResultType.Success : StatusResultType.Error,
                    Actions = new List<HealthCheckAction> ()
            };
        }
    }
}