using System.Linq;
using Microsoft.AspNet.Http;
using CEverett.Models;
using MarkdownSharp;

namespace CEverett.ViewModels
{
	public class PostViewModel : Post
	{
		public PostViewModel(Post post, HttpRequest request)
		{
            var md = new Markdown();
			this.Content = md.Transform(post.Content);
			this.Id = post.Id;
			this.PostDateTime = post.PostDateTime;
			this.Summary = md.Transform(post.Summary);
            this.Splash = post.Splash;
            this.TwitterSplash = FullUrl(post.TwitterSplash, request);
            this.TwitterSmallSplash = FullUrl(post.TwitterSmallSplash, request);
            this.Color = post.Color;
            this.SecondaryColor = post.SecondaryColor;
            this.Background = post.Background;
			this.Tags = post.Tags.ToArray();
			this.Title = post.Title;
            this.Hidden = post.Hidden;
		}
        
        private static string FullUrl(string relative, HttpRequest request)
        {
            if(relative == null) { return null; }
            return string.Format("{0}://{1}{2}", request.Scheme, request.Host, relative);
        }
	}
}