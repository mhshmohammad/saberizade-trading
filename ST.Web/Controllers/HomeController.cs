using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ST.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : STControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}