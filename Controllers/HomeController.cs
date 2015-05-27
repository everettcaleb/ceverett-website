using System.Linq;
using System.Threading.Tasks;
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
		public async Task<ActionResult> Index(string q = null)
		{
			return View((await postProvider.Get(100, 0, q)).Select(p => new PostViewModel(p)));
		}
		
		[HttpGet]
		[Route("post/{id}")]
		public async Task<ActionResult> Post(string id)
		{
			var post = await postProvider.Get(id);
			if (post == null)
			{
				return HttpNotFound();
			}
			return View(new PostViewModel(post));
		}
        
        [HttpGet]
        [Route("debug")]
        public ActionResult Debug()
        {
            return Json(new {
                HOME = System.Environment.GetEnvironmentVariable("HOME"),
                HOME_EXPANDED = System.Environment.GetEnvironmentVariable("HOME_EXPANDED")
            });
        }
	}
}