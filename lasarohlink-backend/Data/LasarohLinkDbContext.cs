using lasarohlink_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lasarohlink_backend.Data
{
	public class LasarohLinkDbContext : DbContext
	{
		public DbSet<Url> Urls { get; set; }
		public DbSet<Log> Logs { get; set; }

		public LasarohLinkDbContext(DbContextOptions<LasarohLinkDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Url>()
				.Property(x => x.ShortenedUrl).ValueGeneratedOnAddOrUpdate();
			modelBuilder.Entity<Log>()
				.Property(x => x.LogTimestamp).ValueGeneratedOnAddOrUpdate();
		}
	}
}