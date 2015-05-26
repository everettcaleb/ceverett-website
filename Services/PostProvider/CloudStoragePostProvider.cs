using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEverett.Models;

namespace CEverett.Services.PostProvider
{
    public class CloudStoragePostProvider : IPostProvider
    {   
        public async Task<Post> Get(string id)
        {
            var metaPath = string.Format("{0}-meta.json", id);
            var contentPath = string.Format("{0}-content.md", id);
            
            Post post = null;
            
            try
            {
                post = await FileHelper.ReadAllJsonFromBlob<Post>("posts", metaPath);
                post.Content = await FileHelper.ReadAllTextFromBlob("posts", contentPath);
            }
            catch
            {
                return null;
            }
            
            return post;
        }
        
		public async Task<IEnumerable<Post>> Get(int limit, int skip, string search)
        {
            var ids = await FileHelper.ReadAllJsonFromBlob<IEnumerable<string>>("posts", "list.json");
            var posts = new List<Post>();
            var count = 0;
            
            foreach(var id in ids)
            {
                if(posts.Count >= limit)
                {
                    return posts;
                }
                
                var metaPath = string.Format("{0}-meta.json", id);
                var contentPath = string.Format("{0}-content.md", id);
                
                try 
                {   
                    var post = await FileHelper.ReadAllJsonFromBlob<Post>("posts", metaPath);
                    if(search == null || 
                       post.Id.StartsWith(search) ||
                       post.Tags.Any(t => t.StartsWith(search)))
                    {
                        ++count;
                        if(count <= skip)
                        {
                            continue;
                        }
                        
                        post.Content = await FileHelper.ReadAllTextFromBlob("posts", contentPath);
                        posts.Add(post);
                    }
                }
                catch { }
            }
            
            return posts;
        }
        
		public async Task<Post> Save(Post post)
        {
            throw new NotImplementedException();
        }
        
		public async Task Delete(Post post)
        {
            throw new NotImplementedException();
        }
        
		public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}