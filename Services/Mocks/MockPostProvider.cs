using System;
using System.Collections.Generic;
using System.Linq;
using CEverett.Models;

namespace CEverett.Services.Mocks
{
	public class MockPostProvider : IPostProvider 
	{
		static Dictionary<string, Post> posts;
		
		static MockPostProvider()
		{
			var post1 = new Post 
			{
				Id = "post1",
				Title = "Hello World",
				PostDateTime = new DateTime(2015, 05, 15),
				Summary = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet condimentum nulla, at ultricies lectus volutpat nec. Nulla facilisi. Sed dictum neque vel pellentesque pulvinar. Donec efficitur mollis sapien sit amet varius. Sed a porta leo, nec finibus leo. Sed sapien mi, tempor vitae ligula ac, porttitor feugiat erat. Donec id ex a augue viverra tempor venenatis sit amet orci. Vestibulum fermentum dapibus sem et blandit. Maecenas non erat varius, vulputate tellus in, varius dui.",
				Tags = new List<string> { "lorem", "ipsum", "post1" },
				Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet condimentum nulla, at ultricies lectus volutpat nec. Nulla facilisi. Sed dictum neque vel pellentesque pulvinar. Donec efficitur mollis sapien sit amet varius. Sed a porta leo, nec finibus leo. Sed sapien mi, tempor vitae ligula ac, porttitor feugiat erat. Donec id ex a augue viverra tempor venenatis sit amet orci. Vestibulum fermentum dapibus sem et blandit. Maecenas non erat varius, vulputate tellus in, varius dui.

Proin felis nibh, venenatis vitae tincidunt quis, hendrerit vitae lacus. Morbi vitae sem commodo, aliquet nulla nec, tincidunt nisl. Duis sagittis, lorem ac maximus varius, ligula nunc feugiat dui, a imperdiet elit arcu non sapien. Sed aliquet metus sed nisl malesuada maximus. Vestibulum laoreet est nisi, vitae posuere quam auctor eu. Quisque pharetra aliquet metus ac rutrum. Ut ultricies, orci sit amet imperdiet rhoncus, lectus turpis placerat nisl, et fermentum eros lectus sit amet felis. Nullam eleifend neque sapien, non dictum velit aliquet vel. Etiam ac hendrerit lacus. Donec condimentum mi sit amet est hendrerit, quis semper erat imperdiet. Etiam sapien erat, maximus quis purus vitae, blandit luctus est. Praesent sed arcu et mi lobortis tristique sed sit amet elit. Nullam vulputate mi ut eros lacinia, non ornare lacus tincidunt. Ut varius augue laoreet lectus sodales suscipit.

Cras sapien massa, malesuada vel consequat vel, ullamcorper eget est. Fusce rhoncus id mauris sit amet mattis. Vestibulum id metus eu nisl convallis vehicula. Suspendisse quis justo at mi bibendum fringilla. Proin blandit nulla metus, ut pulvinar turpis varius et. Duis luctus lacinia tellus at ultrices. Vivamus eget felis quis erat porta consectetur. Sed volutpat ligula sit amet magna ultricies lacinia.

Aenean condimentum efficitur dolor, in venenatis nunc luctus ut. Morbi vehicula rhoncus ante in feugiat. Nam vitae feugiat augue, eu tempor ante. Ut auctor, velit sed fermentum tincidunt, dolor urna pretium nisl, eget convallis mi arcu id urna. Morbi ac lacus orci. Nam sit amet elementum nisi, sit amet condimentum sapien. Aliquam dui risus, efficitur ac urna nec, luctus imperdiet risus. Vestibulum lacus eros, finibus ut ipsum pharetra, bibendum ultrices orci. Proin ligula diam, ornare eu enim sit amet, ultrices elementum arcu. Sed euismod venenatis libero, at semper nisl finibus in.

Vestibulum luctus, felis at maximus facilisis, orci sapien dignissim quam, sit amet mattis enim lacus id lectus. Phasellus porttitor quam et nibh varius, sit amet ultricies felis tristique. Curabitur faucibus dapibus finibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris quis volutpat leo. Pellentesque semper hendrerit nibh. Sed cursus elementum augue, ac faucibus enim condimentum ut. Pellentesque rutrum sit amet metus id dictum. Praesent vitae lacus a dolor semper consequat sed nec mi. Suspendisse et lacus magna. Cras gravida laoreet aliquam. Cras tristique velit orci, vel maximus mauris pretium nec. Donec convallis pulvinar orci, vitae faucibus erat lacinia ac."
			};
			
			var post2 = new Post 
			{
				Id = "post2",
				Title = "The Second Post",
				PostDateTime = new DateTime(2015, 05, 18),
				Summary = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet condimentum nulla, at ultricies lectus volutpat nec. Nulla facilisi. Sed dictum neque vel pellentesque pulvinar. Donec efficitur mollis sapien sit amet varius. Sed a porta leo, nec finibus leo. Sed sapien mi, tempor vitae ligula ac, porttitor feugiat erat. Donec id ex a augue viverra tempor venenatis sit amet orci. Vestibulum fermentum dapibus sem et blandit. Maecenas non erat varius, vulputate tellus in, varius dui.",
				Tags = new List<string> { "lorem", "ipsum", "post2", "second" },
				Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet condimentum nulla, at ultricies lectus volutpat nec. Nulla facilisi. Sed dictum neque vel pellentesque pulvinar. Donec efficitur mollis sapien sit amet varius. Sed a porta leo, nec finibus leo. Sed sapien mi, tempor vitae ligula ac, porttitor feugiat erat. Donec id ex a augue viverra tempor venenatis sit amet orci. Vestibulum fermentum dapibus sem et blandit. Maecenas non erat varius, vulputate tellus in, varius dui.

Proin felis nibh, venenatis vitae tincidunt quis, hendrerit vitae lacus. Morbi vitae sem commodo, aliquet nulla nec, tincidunt nisl. Duis sagittis, lorem ac maximus varius, ligula nunc feugiat dui, a imperdiet elit arcu non sapien. Sed aliquet metus sed nisl malesuada maximus. Vestibulum laoreet est nisi, vitae posuere quam auctor eu. Quisque pharetra aliquet metus ac rutrum. Ut ultricies, orci sit amet imperdiet rhoncus, lectus turpis placerat nisl, et fermentum eros lectus sit amet felis. Nullam eleifend neque sapien, non dictum velit aliquet vel. Etiam ac hendrerit lacus. Donec condimentum mi sit amet est hendrerit, quis semper erat imperdiet. Etiam sapien erat, maximus quis purus vitae, blandit luctus est. Praesent sed arcu et mi lobortis tristique sed sit amet elit. Nullam vulputate mi ut eros lacinia, non ornare lacus tincidunt. Ut varius augue laoreet lectus sodales suscipit.

Cras sapien massa, malesuada vel consequat vel, ullamcorper eget est. Fusce rhoncus id mauris sit amet mattis. Vestibulum id metus eu nisl convallis vehicula. Suspendisse quis justo at mi bibendum fringilla. Proin blandit nulla metus, ut pulvinar turpis varius et. Duis luctus lacinia tellus at ultrices. Vivamus eget felis quis erat porta consectetur. Sed volutpat ligula sit amet magna ultricies lacinia.

Aenean condimentum efficitur dolor, in venenatis nunc luctus ut. Morbi vehicula rhoncus ante in feugiat. Nam vitae feugiat augue, eu tempor ante. Ut auctor, velit sed fermentum tincidunt, dolor urna pretium nisl, eget convallis mi arcu id urna. Morbi ac lacus orci. Nam sit amet elementum nisi, sit amet condimentum sapien. Aliquam dui risus, efficitur ac urna nec, luctus imperdiet risus. Vestibulum lacus eros, finibus ut ipsum pharetra, bibendum ultrices orci. Proin ligula diam, ornare eu enim sit amet, ultrices elementum arcu. Sed euismod venenatis libero, at semper nisl finibus in.

Vestibulum luctus, felis at maximus facilisis, orci sapien dignissim quam, sit amet mattis enim lacus id lectus. Phasellus porttitor quam et nibh varius, sit amet ultricies felis tristique. Curabitur faucibus dapibus finibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris quis volutpat leo. Pellentesque semper hendrerit nibh. Sed cursus elementum augue, ac faucibus enim condimentum ut. Pellentesque rutrum sit amet metus id dictum. Praesent vitae lacus a dolor semper consequat sed nec mi. Suspendisse et lacus magna. Cras gravida laoreet aliquam. Cras tristique velit orci, vel maximus mauris pretium nec. Donec convallis pulvinar orci, vitae faucibus erat lacinia ac."
			};
			
			posts = new Dictionary<string, Post> {
				{ "post1", post1 },
				{ "post2", post2 }
			};
		}
		
		public Post Get(string id)
		{
			if(posts.ContainsKey(id))
			{
				return posts[id];	
			}
			return null;
		}
		
		public IEnumerable<Post> Get(int limit, int skip, string search)
		{
			return posts.Select(kv => kv.Value)
						.Where(p => p.Id.StartsWith(search) ||
									p.Tags.Any(t => t.StartsWith(search)))
						.Skip(skip)
						.Take(limit)
						.OrderByDescending(p => p.PostDateTime);
		}
		
		public Post Save(Post post)
		{
			if(posts.ContainsKey(post.Id))
			{
				posts[post.Id] = post;
			}
			else 
			{
				posts.Add(post.Id, post);
			}
			return post;
		}
		
		public void Delete(Post post)
		{
			Delete(post.Id);
		}
		
		public void Delete(string id)
		{
			if(posts.ContainsKey(id))
			{
				posts.Remove(id);
			}
		}
	}
}