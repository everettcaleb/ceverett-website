using System;
using System.Collections.Generic;

namespace CEverett.Models
{
	public class Post
	{
		public Post()
		{
		}
		
		public string Id { get; set; }
		public string Title { get; set; }
		public DateTime PostDateTime { get; set; }
		public string Summary { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public string Content { get; set; }
	}
}