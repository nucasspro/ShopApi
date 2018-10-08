using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models
{
    public class ShopDbContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CcTransaction> CcTransactions { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected ShopDbContext() : base()
        {
        }

        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Shop");
            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.Entity<Product>().ToTable("Product");

            // Create Category table
            // Done
            modelBuilder.Entity<Category>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.ParentId)
                        .HasColumnName("ParentId")
                        .HasColumnType("INT");

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create Product table
            // Done
            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Sku)
                        .HasColumnName("Sku")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Description)
                        .HasColumnName("Description")
                        .HasColumnType("TEXT");

                    entity
                        .HasOne(x => x.ProductStatusId)
                        .WithMany(y => y.Products);

                    entity
                        .Property(x => x.RegularPrice)
                        .HasColumnName("RegularPrice")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    entity
                        .Property(x => x.DiscountPrice)
                        .HasColumnName("DiscountPrice")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    entity
                        .Property(x => x.Quantity)
                        .HasColumnName("Quantity")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    entity
                        .Property(x => x.Texable)
                        .HasColumnName("Tex")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create ProductCategory table
            // Done
            modelBuilder.Entity<ProductCategory>(
                entity =>
                {
                    entity
                        .HasKey(x => new { x.ProductId, x.CategoryId });

                    entity
                        .HasOne(x => x.Product)
                        .WithMany(y => y.ProductCategories)
                        .HasForeignKey(z => z.ProductId);

                    entity
                        .HasOne(x => x.Category)
                        .WithMany(y => y.ProductCategories)
                        .HasForeignKey(z => z.CategoryId);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create ProductStatus table
            // Done
            modelBuilder.Entity<ProductStatus>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create Tag table
            // Done
            modelBuilder.Entity<Tag>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create ProductTag table
            // Done
            modelBuilder.Entity<ProductTag>(
                entity =>
                {
                    entity
                        .HasKey(x => new { x.ProductId, x.TagId });

                    entity
                        .HasOne(x => x.Product)
                        .WithMany(y => y.ProductTags)
                        .HasForeignKey(z => z.ProductId);

                    entity
                        .HasOne(x => x.Tag)
                        .WithMany(y => y.ProductTags)
                        .HasForeignKey(z => z.TagId);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create Role table
            // Done
            modelBuilder.Entity<Role>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create User table
            // Done
            modelBuilder.Entity<User>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Email)
                        .HasColumnName("Email")
                        .HasColumnType("VARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.FirstName)
                        .HasColumnName("FirstName")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.LastName)
                        .HasColumnName("LastName")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Active)
                        .HasColumnName("Active")
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create UserRole table
            // Done
            modelBuilder.Entity<UserRole>(
                entity =>
                {
                    entity
                        .HasKey(x => new { x.UserId, x.RoleId });

                    entity
                        .HasOne(x => x.User)
                        .WithMany(y => y.UserRoles)
                        .HasForeignKey(z => z.UserId);

                    entity
                        .HasOne(x => x.Role)
                        .WithMany(y => y.UserRoles)
                        .HasForeignKey(z => z.RoleId);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create OrderProduct table
            // Done
            modelBuilder.Entity<OrderProduct>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .HasOne(x => x.OrderId)
                        .WithMany(y => y.OrderProducts);

                    entity
                        .Property(x => x.Sku)
                        .HasColumnName("Sku")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Name)
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Description)
                        .HasColumnName("Description")
                        .HasColumnType("TEXT");

                    entity
                        .Property(x => x.Price)
                        .HasColumnName("Price")
                        .HasColumnType("INT")
                        .IsRequired();

                    entity
                        .Property(x => x.Quantity)
                        .HasColumnName("Quantity")
                        .HasColumnType("INT")
                        .IsRequired();

                    entity
                        .Property(x => x.SubTotal)
                        .HasColumnName("SubTotal")
                        .HasColumnType("INT")
                        .IsRequired();

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create CcTransaction table
            // Done
            modelBuilder.Entity<CcTransaction>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Code)
                        .HasColumnName("Code")
                        .HasColumnType("NVARCHAR")
                        .HasMaxLength(255);

                    entity
                        .HasOne(x => x.OrderId)
                        .WithMany(y => y.CcTransactions);

                    entity
                        .Property(x => x.TransactionDate)
                        .HasColumnName("TransactionDate")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.Processor)
                        .HasColumnName("Processor")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.ProcessorTransactionId)
                        .HasColumnName("ProcessorTransactionId")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Amount)
                        .HasColumnName("Amount")
                        .HasColumnType("INT")
                        .IsRequired();

                    entity
                        .Property(x => x.CcNum)
                        .HasColumnName("CcNum")
                        .HasColumnType("NVARCHAR")
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.CcType)
                        .HasColumnName("CcType")
                        .HasColumnType("NVARCHAR")
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Response)
                        .HasColumnName("Response")
                        .HasColumnType("TEXT");

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create Session table
            // Done
            modelBuilder.Entity<Session>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Data)
                        .HasColumnName("Data")
                        .HasColumnType("TEXT");

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create Coupon table
            // Done
            modelBuilder.Entity<Coupon>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.Code)
                        .HasColumnName("Code")
                        .HasColumnType("NVARCHAR")
                        .IsRequired()
                        .HasMaxLength(255);

                    entity
                        .Property(x => x.Description)
                        .HasColumnName("Description")
                        .HasColumnType("TEXT");

                    entity
                        .Property(x => x.Active)
                        .HasColumnName("Active")
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    entity
                        .Property(x => x.Value)
                        .HasColumnName("Value")
                        .HasColumnType("INT");

                    entity
                        .Property(x => x.Multiple)
                        .HasColumnName("Multiple")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    entity
                        .Property(x => x.StartDate)
                        .HasColumnName("StartDate")
                        .HasColumnType("DATETIME")
                        .IsRequired();

                    entity
                        .Property(x => x.EndDate)
                        .HasColumnName("EndDate")
                        .HasColumnType("DATETIME")
                        .IsRequired();

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );

            // Create SalesOrder table
            // Done
            modelBuilder.Entity<SalesOrder>(
                entity =>
                {
                    entity
                        .HasKey(x => x.Id);

                    entity
                        .Property(x => x.OrderDate)
                        .HasColumnName("OrderDate")
                        .HasColumnType("DATETIME")
                        .IsRequired();

                    entity
                        .Property(x => x.Total)
                        .HasColumnName("Total")
                        .HasColumnType("INT")
                        .IsRequired();

                    entity
                        .HasOne(x => x.CouponId)
                        .WithMany(y => y.SalesOrders);

                    entity
                        .HasOne(x => x.SessionId)
                        .WithMany(y => y.SalesOrders);

                    entity
                        .HasOne(x => x.UserId)
                        .WithMany(y => y.SalesOrders);

                    entity
                        .Property(x => x.InsertedAt)
                        .HasColumnName("InsertedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAdd();

                    entity
                        .Property(x => x.UpdatedAt)
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("DATETIME")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();
                }
            );
        }
    }
}