using lasarohlink_backend.Data;
using lasarohlink_backend.Models;

namespace lasarohlink_backend.Services
{
	public class LogService
	{
		private readonly LasarohLinkDbContext context;

		public LogService(LasarohLinkDbContext context)
		{
			this.context = context;
		}

		public void SaveLog(Exception ex, HttpContext httpContext)
		{
			string userIp = httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
			string userAgent = httpContext.Request.Headers.UserAgent.ToString();

			Log log = new(ex.Message, ex.StackTrace, userIp, userAgent);
			context.Logs.Add(log);
			context.SaveChanges();

			if (ex.InnerException != null)
				SaveLog(ex.InnerException, httpContext);
		}
	}
}