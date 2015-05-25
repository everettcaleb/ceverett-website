using System.Collections.Generic;
using CEverett.Models;

namespace CEverett.Services 
{
	public interface IPostProvider
	{
		Post Get(string id);
		IEnumerable<Post> Get(int limit, int skip, string search);
		Post Save(Post post);
		void Delete(Post post);
		void Delete(string id);
	}
}