using Hon.Model;

namespace Hon.Persistence;

public class HonDbContext : DbContext
{
	public HonDbContext(DbContextOptions<HonDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
	public DbSet<SampleModel> Samples { get; set; } 
	public DbSet<Card> Card {get;set;}
	public DbSet<Category> Category {get;set;}
	public DbSet<Reminder> Reminder {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<SampleModel>().HasKey(s => s.SampleId);

		modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

		modelBuilder.Entity<Card>().HasKey(c => c.CardId);

		modelBuilder.Entity<Reminder>().HasKey(r => r.ReminderId);

		modelBuilder.Entity<Card>()
			.HasOne(c => c.Category)
			.WithMany()
			.HasForeignKey(c => c.CategoryId)
			.OnDelete(DeleteBehavior.SetNull)
			.IsRequired(false);	

		modelBuilder.Entity<Card>()
			.HasOne(c => c.Reminder)
			.WithMany()
			.HasForeignKey(c => c.ReminderId)
			.OnDelete(DeleteBehavior.SetNull)
			.IsRequired(false);

		base.OnModelCreating(modelBuilder);
	}
}
