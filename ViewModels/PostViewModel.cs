using System.Linq;
using CEverett.Models;
using MarkdownSharp;

namespace CEverett.ViewModels
{
	public class PostViewModel : Post
	{
		public PostViewModel(Post post)
		{
            var md = new Markdown();
			this.Content = md.Transform(post.Content);
			this.Id = post.Id;
			this.PostDateTime = post.PostDateTime;
			this.Summary = md.Transform(post.Summary);
            this.Splash = post.Splash;
            this.Color = post.Color;
            this.SecondaryColor = post.SecondaryColor;
            this.Background = post.Background;
			this.Tags = post.Tags.ToArray();
			this.Title = post.Title;
		}
	}
}