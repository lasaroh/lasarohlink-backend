using lasarohlink_backend.Helpers;
using lasarohlink_backend.Models;
using lasarohlink_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace lasarohlink_backend.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class UrlController(IConfiguration configuration, UrlService urlService, LogService logService) : ControllerBase
	{
		private readonly string? _baseUrl = configuration["BaseUrl"];

		[HttpPost]
		public IActionResult ShortenUrl([FromForm] string url)
		{
			try
			{
				if (!Helper.IsValidUrl(url))
					return BadRequest(new { error = "Invalid URL. It must be a well-formed URL." });

				Url newUrl = urlService.SaveUrl(Helper.GenerateHash(url), url);

				return Ok(new { ShortenedUrl = _baseUrl + newUrl.ShortenedUrl });
			}
			catch (Exception ex)
			{
				logService.SaveLog(ex, HttpContext);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Unexpected error" });
			}
		}

		[HttpGet("{ShortenedUrl}")]
		public IActionResult RedirectToOriginalUrl(string ShortenedUrl)
		{
			try
			{
				Url? url = urlService.GetUrlByShortenedUrl(ShortenedUrl);

				if (url == null)
					return NotFound(new { message = "The URL does not exists or is incorrect." });

				return Redirect(url.UrlOriginal);
			}
			catch (Exception ex)
			{
				logService.SaveLog(ex, HttpContext);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Unexpected error" });
			}
		}
	}
}