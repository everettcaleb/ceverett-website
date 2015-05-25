using System.Linq;
using CEverett.Models;

namespace CEverett.ViewModels
{
	public class PostViewModel : Post
	{
		public PostViewModel(Post post)
		{
			this.Content = post.Content;
			this.Id = post.Id;
			this.PostDateTime = post.PostDateTime;
			this.Summary = post.Summary;
			this.Tags = post.Tags.ToArray();
			this.Title = post.Title;
		}
	}
}