using Microsoft.AspNet.Mvc;

namespace CEverett.Controllers 
{
	[Route("")]
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}