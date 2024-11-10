namespace lasarohlink_backend.Models
{
	public class Url(string UrlHash, string UrlOriginal)
	{
		public int Id { get; set; }
		public string UrlHash { get; set; } = UrlHash;
		public string UrlOriginal { get; set; } = UrlOriginal;
		public string? ShortenedUrl { get; set; }
	}
}