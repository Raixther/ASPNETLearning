using Microsoft.EntityFrameworkCore;

using WebApp.Entities;

namespace WebApp.EntityFramework
{
	public class PersonsDbContext:DbContext
	{
		public	DbSet<PersonEntity> Persons{ get; set;}

		public PersonsDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database=usersdb;Username=postgres;Password=qazvfr231");
		}

	}
}
