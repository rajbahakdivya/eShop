using eShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CatalogItem>CatalogItems { get; set; }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            builder.Entity<CatalogType>(ConfigureCatalogType);
            builder.Entity<CatalogItem>(ConfigureCatalogItem);
        }

        void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.Id)
                .UseHiLo("Catalog_brand_hilo")
                .IsRequired();
            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);

        }

        void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id)
                .UseHiLo("Catalog_type_hilo")
                .IsRequired();
            builder.Property(ct => ct.Type)
                .IsRequired()
                .HasMaxLength(100);

        }

        void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.HasKey(ci => ci.Id);
            builder.Property(ct => ct.Id)
                .UseHiLo("Catalog_type_hilo")
                .IsRequired();

            builder.Property(ct => ct.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(ct => ct.Price)
                .IsRequired(true);

            builder.Property(ct => ct.PictureUrl)
                .IsRequired(false);

            builder.HasOne(ci => ci.CatalogBrand)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogBrandId);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogTypeId);



        }
    }
}
