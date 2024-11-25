using lasarohlink_backend.Data;
using lasarohlink_backend.Models;

namespace lasarohlink_backend.Services
{
	public class UrlService
	{
		private readonly LasarohLinkDbContext context;

		public UrlService(LasarohLinkDbContext context)
		{
			this.context = context;
		}

		public Url SaveUrl(string UrlHash, string UrlOriginal)
		{
			Url url = new(UrlHash, UrlOriginal);
			context.Urls.Add(url);
			context.SaveChanges();

			return url;
		}

		public Url? GetUrlByShortenedUrl(string shortenedUrl)
		{
			return context.Urls.FirstOrDefault(x => x.ShortenedUrl == shortenedUrl);
		}
	}
}