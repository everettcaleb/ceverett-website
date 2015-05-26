using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public string Splash { get; set; }
        public string Color { get; set; }
        public string SecondaryColor { get; set; }
        public string Background { get; set; }
		public IEnumerable<string> Tags { get; set; }
        [JsonIgnore]
		public string Content { get; set; }
	}
}