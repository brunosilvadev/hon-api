using Hon.Model;

namespace Hon.Persistence;

public class HonDbContext : DbContext
{
	public HonDbContext(DbContextOptions<HonDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
	public DbSet<SampleModel> Samples { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
}

}
