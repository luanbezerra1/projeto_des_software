using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Produto> Produtos => Set<Produto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var produto = modelBuilder.Entity<Produto>();
        produto
            .Property(p => p.Preco)
            .HasPrecision(18, 2)
            .IsRequired();

        produto
            .Property(p => p.Nome)
            .HasMaxLength(120)
            .IsRequired();
    }

}