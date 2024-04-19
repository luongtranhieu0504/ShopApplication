using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;
using Npgsql;

namespace ShopApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
            .HasOne(c => c.product)
            .WithMany(p => p.comments)
            .HasForeignKey(c => c.productId);


            modelBuilder.Entity<Product>()
                .HasMany(p => p.images)
                .WithOne(i => i.product)
                .HasForeignKey(i => i.producId);

			modelBuilder.Entity<OrderToProduct>()
				.HasKey(op => new { op.OrderId, op.ProductId });

			modelBuilder.Entity<OrderToProduct>()
				.HasOne(op => op.Order)
				.WithMany(o => o.orderToProducts)
				.HasForeignKey(op => op.OrderId);

			modelBuilder.Entity<OrderToProduct>()
				.HasOne(op => op.Product)
				.WithMany(p => p.orderToProducts)
				.HasForeignKey(op => op.ProductId);

			modelBuilder.Entity<ProductTag>()
	            .HasKey(pt => new { pt.ProductId, pt.TagId });

			modelBuilder.Entity<ProductTag>()
				.HasOne(pt => pt.Product)
				.WithMany(p => p.productTags)
				.HasForeignKey(pt => pt.ProductId);

			modelBuilder.Entity<ProductTag>()
				.HasOne(pt => pt.Tag)
				.WithMany(t => t.ProductTags)
				.HasForeignKey(pt => pt.TagId);

		}


    }
}
