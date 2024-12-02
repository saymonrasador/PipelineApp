using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Exemplo de tabela fictícia
    public DbSet<Example> Examples { get; set; }
    public DbSet<Product> Products { get; set; } // Adicione esta linha

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

public class Example
{
    public int Id { get; set; }
    public required string Name { get; set; }
}