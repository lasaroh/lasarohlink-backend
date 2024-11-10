namespace lasarohlink_backend.Models
{
	public class Log
	{
		public int Id { get; set; }
		public DateTime? LogTimestamp { get; set; }
		public string LogMessage { get; set; }
		public string? Exception { get; set; }
		public string UserIP { get; set; }
		public string UserAgent { get; set; }

		// EF Core requires a parameterless constructor to create instances of the class and assign default values like LogTimestamp
		public Log()
		{
			LogMessage = string.Empty;
			UserIP = string.Empty;
			UserAgent = string.Empty;
		}

		public Log(string logMessage, string? exception, string userIp, string userAgent)
		{
			LogMessage = logMessage;
			Exception = exception;
			UserIP = userIp;
			UserAgent = userAgent;
		}
	}
}