// https://our.umbraco.com/Documentation/implementation/composing/

using System;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Services.Implement;

namespace $rootnamespace$ {
    public class $safeitemname$ : IComponent {
        // initialize: runs once when Umbraco starts
        public void Initialize () {
            //do something as Umbraco starts up
            //for example subscribe to an event
        }

        // terminate: runs once when Umbraco stops
        public void Terminate () {
            // do something when Umbraco terminates
        }
    }

[RuntimeLevel (MinLevel = RuntimeLevel.Run)]
    public class $safeitemname$ : ComponentComposer<$safeitemname$>
    {
        // nothing needed to be done here!
    }
}