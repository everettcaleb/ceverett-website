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
			this.Summary = post.Summary;
            this.Splash = post.Splash;
            this.TwitterSplash = post.TwitterSplash;
            this.TwitterSmallSplash = post.TwitterSmallSplash;
            this.Color = post.Color;
            this.SecondaryColor = post.SecondaryColor;
            this.Background = post.Background;
			this.Tags = post.Tags.ToArray();
			this.Title = post.Title;
            this.Hidden = post.Hidden;
		}
	}
}