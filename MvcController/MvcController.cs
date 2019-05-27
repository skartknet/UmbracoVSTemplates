using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

/// <summary>
/// If you need complete control over how your pages are rendered then Hijacking Umbraco Routes is for you.
/// https://our.umbraco.com/documentation/Reference/Routing/custom-controllers
/// </summary>
namespace $rootnamespace$
{

    public class $safeitemname$ : RenderMvcController
    {
        public override ActionResult Index (ContentModel model)
        {
            // Do some stuff here, then return the base method
            return base.Index (model);
        }
    }
}