using System.Security.Cryptography;
using System.Text;

namespace lasarohlink_backend.Helpers
{
	public class Helper
	{
		/// <summary>
		/// Generates a SHA-256 hash for the specified input string and returns it as a hexadecimal string.
		/// </summary>
		/// <param name="value">The input string to be hashed.</param>
		/// <returns>A hexadecimal string representation of the SHA-256 hash of the input string.</returns>
		public static string GenerateHash(string value)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			byte[] hashBytes = SHA256.HashData(bytes);

			StringBuilder HashString = new();
			foreach (byte b in hashBytes)
			{
				HashString.Append(b.ToString("x2"));
			}

			return HashString.ToString();
		}

		/// <summary>
		/// Validates a URL.
		/// </summary>
		/// <param name="url">The URL to be validated.</param>
		/// <returns>A boolean indicating whether the URL is valid or not.</returns>
		public static bool IsValidUrl(string url)
		{
			return
				Uri.TryCreate(url, UriKind.Absolute, out Uri? UriResult) &&
				(UriResult.Scheme == Uri.UriSchemeHttp || UriResult.Scheme == Uri.UriSchemeHttps);
		}
	}
}