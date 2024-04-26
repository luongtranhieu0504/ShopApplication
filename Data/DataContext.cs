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
		public DbSet<Tag> Tags { get; set; }
		public DbSet<CartItem> Carts { get; set; }
		public DbSet<User> Users { get; set; }

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

			modelBuilder.Entity<Order>()
			.HasMany(o => o.orderToCarts) 
			.WithOne(otc => otc.order)    
			.HasForeignKey(otc => otc.orderId);

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
