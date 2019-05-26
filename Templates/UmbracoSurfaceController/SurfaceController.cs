using System.Web.Mvc;
using Umbraco.Web.Mvc;

/// <summary>
/// A $safeitemname$ is an MVC controller that interacts with the front-end rendering of an UmbracoPage. 
/// Is auto routed, meaning you don't have to setup any custom routes to make it work
/// https://our.umbraco.com/Documentation/Reference/Routing/surface-controllers
/// </summary>
namespace $webnamespace$
{
    public class $itemname$ : $safeitemname$
    {
        //GET: /umbraco/surface/{controllername}/{action}/{id}
        public ActionResult Index()
        {

        }
    }
}