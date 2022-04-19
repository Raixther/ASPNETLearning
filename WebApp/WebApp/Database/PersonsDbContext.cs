using Microsoft.EntityFrameworkCore;

using WebApp.Models;

namespace WebApp.Database
{
	public sealed class PersonsDbContext:DbContext
	{
		public	DbSet<PersonEntity> Persons{ get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=vma-postgres; Database=vma;Username =vma; Password =12wfwtwt;");////
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}	
}
