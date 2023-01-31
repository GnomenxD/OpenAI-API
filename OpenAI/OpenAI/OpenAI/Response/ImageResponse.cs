using Cosmos.AI.Open_AI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmos.AI
{
	public class ImageResponse
	{
		private bool fetched;
		private readonly long created;
		private readonly string[] urls;

		public long Created => created;
		public string? Url => urls.Length > 0 ? Urls[0] : null;
		public string[] Urls => urls;
		public int Count => Urls.Length;

		public ImageResponse(long created, string[] urls)
		{
			this.created = created;
			this.urls = urls;
		}

		public static ImageResponse Generate(ImageResponseContent resp)
		{
			if(resp.data == null)
			{
				Console.WriteLine($"No returned data.");
			}
			string[] urls = new string[resp.data != null ? resp.data.Count : 0];
			for(int i = 0; i < urls.Length; i++)
			{
				urls[i] = resp.data[i].url;
			}
			return new ImageResponse(resp.created, urls);
		}
	}
}