using Microsoft.EntityFrameworkCore;

using WebApp.Entities;

namespace WebApp.EntityFramework
{
	public class AppDbContext:DbContext
	{
		public	DbSet<PersonEntity> Persons{ get; set;}

		public DbSet<UserEntity> Users { get; set; }


		public AppDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database = WebAppDb;Username=postgres;Password=qazvfr231");
		}

	}
}
