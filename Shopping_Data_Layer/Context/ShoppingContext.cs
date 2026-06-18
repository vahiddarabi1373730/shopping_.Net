using Microsoft.EntityFrameworkCore;
using Shopping_Data_Layer.Entities.Access;
using Shopping_Data_Layer.Entities.Account;
using Shopping_Data_Layer.Entities.Order;
using Shopping_Data_Layer.Entities.Product;
using Shopping_Data_Layer.Entities.Site;

namespace Shopping_Data_Layer.Context;

public class ShoppingContext : DbContext
{
    #region Constructor

    public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
    {
    }

    #endregion


    #region DBSets

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductGallery> ProductGalleries { get; set; }
    public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }
    public DbSet<ProductVisit> ProductVisits { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    #endregion


    #region Cascade

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascades = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (var cascade in cascades)
        {
            cascade.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}