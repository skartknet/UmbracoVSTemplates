using System.Web.Mvc;
using Umbraco.Web.Models;

/// <summary>
/// If you need complete control over how your pages are rendered then Hijacking Umbraco Routes is for you.
/// https://our.umbraco.com/documentation/Reference/Routing/custom-controllers
/// </summary>
namespace $webnamespace$
{

    public class $itemname$ : Umbraco.Web.Mvc.RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            // Do some stuff here, then return the base method
            return base.Index(model);
        }
    }
}