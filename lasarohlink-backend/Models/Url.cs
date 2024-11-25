namespace lasarohlink_backend.Models
{
	public class Url
	{
		public int Id { get; set; }
		public string UrlHash { get; set; }
		public string UrlOriginal { get; set; }
		public string? ShortenedUrl { get; set; }

		public Url(string UrlHash, string UrlOriginal)
		{
			this.UrlHash = UrlHash;
			this.UrlOriginal = UrlOriginal;
		}
	}
}