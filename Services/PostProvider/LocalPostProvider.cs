using System;
using System.Collections.Generic;
using System.Linq;
using CEverett.Models;

namespace CEverett.Services.PostProvider
{
    public class LocalPostProvider : IPostProvider
    {
        public Post Get(string id)
        {
            throw new NotImplementedException();
        }
        
		public IEnumerable<Post> Get(int limit, int skip, string search)
        {
            throw new NotImplementedException();
        }
        
		public Post Save(Post post)
        {
            throw new NotImplementedException();
        }
        
		public void Delete(Post post)
        {
            throw new NotImplementedException();
        }
        
		public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}