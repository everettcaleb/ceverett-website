using System;
using System.Collections.Generic;
using System.Linq;
using CEverett.Models;

namespace CEverett.Services.PostProvider
{
    public class CachePostProviderDecorator : IPostProvider
    {
        private IPostProvider provider;
        private int timeToLive;
        private DateTime lastRefreshDateTime;
        private Dictionary<string, Post> posts;
        
        public CachePostProviderDecorator(IPostProvider provider, int timeToLive = 60)
        {
            this.provider = provider;
            this.timeToLive = timeToLive;
            this.lastRefreshDateTime = new DateTime(1900, 1, 1);
            this.posts = new Dictionary<string, Post>();
        }
        
        public Post Get(string id)
        {
            Refresh();
            lock(posts)
            {
                if(posts.ContainsKey(id))
                {
                    return posts[id];
                }
            }
            return null;
        }
        
		public IEnumerable<Post> Get(int limit, int skip, string search)
        {
            Refresh();
            lock(posts)
            {
                return posts.Select(kv => kv.Value)
                    .Where(p => string.IsNullOrWhiteSpace(search) ||
                       p.Id.StartsWith(search) ||
                       p.Tags.Any(t => t.StartsWith(search)))
                    .Skip(skip)
                    .Take(limit);
            }
        }
        
		public Post Save(Post post)
        {
            post = provider.Save(post);
            Refresh(true);
            return post;
        }
        
		public void Delete(Post post)
        {
            provider.Delete(post);
            Refresh(true);
        }
        
		public void Delete(string id)
        {
            provider.Delete(id);
            Refresh(true);
        }
        
        private void Refresh(bool force = false)
        {
            if(!force && DateTime.UtcNow.Subtract(lastRefreshDateTime).TotalSeconds < timeToLive)
            {
                return;
            }
            
            lock(posts)
            {
                lastRefreshDateTime = DateTime.UtcNow;
                posts.Clear();
                
                var originalPosts = provider.Get(1000, 0, null);
                foreach(var post in originalPosts)
                {
                    post.Tags = post.Tags.Concat(new [] { "cached" });
                    posts.Add(post.Id, post);
                }
            }
        }
    }
}