using System.Collections.Generic;
using System.Threading.Tasks;
using CEverett.Models;

namespace CEverett.Services 
{
	public interface IPostProvider
	{
		Task<Post> Get(string id);
		Task<IEnumerable<Post>> Get(int limit, int skip, string search);
		Task<Post> Save(Post post);
		Task Delete(Post post);
		Task Delete(string id);
	}
}