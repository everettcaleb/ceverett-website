using System.Linq;
using Microsoft.AspNet.Mvc;
using CEverett.Services;
using CEverett.ViewModels;

namespace CEverett.Controllers 
{
	[Route("")]
	public class HomeController : Controller
	{
		private IPostProvider postProvider;
		
		public HomeController(IPostProvider postProvider)
		{
			this.postProvider = postProvider;
		}
		
		[HttpGet]
		public ActionResult Index(string q = "")
		{
			return View(postProvider.Get(10, 0, q).Select(p => new PostViewModel(p)));
		}
		
		[HttpGet]
		[Route("post/{id}")]
		public ActionResult Post(string id)
		{
			var post = postProvider.Get(id);
			if (post == null)
			{
				return HttpNotFound();
			}
			return View(new PostViewModel(post));
		}
	}
}