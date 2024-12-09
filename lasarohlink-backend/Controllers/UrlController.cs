using lasarohlink_backend.Helpers;
using lasarohlink_backend.Models;
using lasarohlink_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace lasarohlink_backend.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class UrlController : ControllerBase
	{
		private readonly string? _BACKEND_URL = Environment.GetEnvironmentVariable("BACKEND_URL") ?? throw new Exception("BACKEND_URL not found");
		private readonly UrlService urlService;
		private readonly LogService logService;

		public UrlController(UrlService urlService, LogService logService)
		{
			this.urlService = urlService;
			this.logService = logService;
		}

		[HttpPost]
		public IActionResult ShortenUrl([FromForm] string url)
		{
			try
			{
				if (!Helper.IsValidUrl(url))
					return BadRequest("Invalid URL. It must be a well-formed URL.");

				Url newUrl = urlService.SaveUrl(Helper.GenerateHash(url), url);

				return Ok(_BACKEND_URL + newUrl.ShortenedUrl);
			}
			catch (Exception ex)
			{
				logService.SaveLog(ex, HttpContext);
				return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error");
			}
		}

		[HttpGet("{ShortenedUrl}")]
		public IActionResult RedirectToOriginalUrl(string ShortenedUrl)
		{
			try
			{
				Url? url = urlService.GetUrlByShortenedUrl(ShortenedUrl);

				if (url == null)
					return NotFound("The URL does not exists or is incorrect.");

				return Redirect(url.UrlOriginal);
			}
			catch (Exception ex)
			{
				logService.SaveLog(ex, HttpContext);
				return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error");
			}
		}
	}
}