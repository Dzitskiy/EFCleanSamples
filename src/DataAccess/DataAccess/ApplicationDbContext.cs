using DataAccess.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        //1
        public DbSet<User> Users { get; set; }

        public DbSet<SuperUser> SuperUsers { get; set; }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserProfile> Categoкшу { get; set; }
        public DbSet<Tag> Categories { get; set; }


       
        //1
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            //2 


            /**/
           // Database.EnsureDeleted();
            /**/
           // Database.EnsureCreated();

            bool isAvalable = Database.CanConnect();
            var isAvalableStr = isAvalable ? "OK!" : "Fail!";

            Console.WriteLine($"Try to connect... {isAvalableStr}");

            //3

            bool isCreated = Database.EnsureCreated();
            if (isCreated) Console.WriteLine("База данных была создана");
            else Console.WriteLine("База данных уже существует");
        }


        //1        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //1
            //optionsBuilder.UseSqlite("Data Source=SQLiteTestDB.db");
            //5

            //optionsBuilder.UseLazyLoadingProxies();

             optionsBuilder.LogTo(Console.WriteLine);
            //.EnableDetailedErrors()

//            optionsBuilder.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);


            //optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Ignore<Company>();

            //modelBuilder.Entity<User>().Property("Id").HasField("id");
            //modelBuilder.Entity<User>().Property("Age").HasField("age");
            //modelBuilder.Entity<User>().ToTable("People");
            //modelBuilder.Entity<User>().ToTable("People", schema: "userstore");
            //modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("user_id");
            //modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();
            //modelBuilder.Entity<User>().HasKey(u => u.Ident).HasName("UsersPrimaryKey");
            //modelBuilder.Entity<User>().HasKey(u => new { u.PassportSeria, u.PassportNumber });
            //modelBuilder.Entity<User>().HasIndex(u => u.Passport);
            //modelBuilder.Entity<User>().HasIndex(u => u.Passport).IsUnique();

            //modelBuilder.Entity<User>().Property(u => u.Age).HasDefaultValue(18);

            modelBuilder.Entity<User>().HasData(FakeDataFactory.Users);
            
            modelBuilder.Entity<SuperUser>().HasData(FakeDataFactory.SuperUsers);


            modelBuilder.Entity<Order>().HasData(FakeDataFactory.Orders);
            modelBuilder.Entity<Product>().HasData(FakeDataFactory.Products);


            //    modelBuilder.Entity<User>()
            //.HasIndex(u => u.PhoneNumber)
            //.HasDatabaseName("PhoneIndex");

            //// TPH
            //modelBuilder.Entity<User>().UseTphMappingStrategy();

            ////TPT 
            //modelBuilder.Entity<User>().UseTptMappingStrategy();

            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Manager>().ToTable("Managers");

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext))!);


            // Используем стратегию TPC
            //modelBuilder.Entity<User>().UseTphMappingStrategy();
            //modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<User>().UseTptMappingStrategy();


            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<UserProfile>().ToTable("Users");

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Tags)
                .WithMany(s => s.Products)
                .UsingEntity(j => j.ToTable("ProductTags"));

            

            //  modelBuilder.Entity<User>()
            //.HasOne(u => u.Profile)
            //.WithOne(o => o.User)
            //.HasForeignKey(o => o.User);



            //modelBuilder.Entity<Order>()
            //  .HasMany(o => o.Users)
            //  .WithMany(u => u.Orders);

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.Products)
            //    .WithMany(p => p.Orders);

            //        modelBuilder.Entity<User>()
            //.HasOne(u => u.UserProfile)
            //.WithOne(up => up.User)
            //.HasForeignKey<UserProfile>(up => up.UserId);


            //modelBuilder.Entity<Order>()
            //.HasMany(o => o.Users)
            //.WithMany(u => u.Orders);

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.Products)
            //    .WithMany(p => p.Orders);

            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.UserProfile)
            //    .WithOne(up => up.User)
            //    .HasForeignKey<UserProfile>(up => up.UserId);

            //modelBuilder.Entity<ProductCategory>()
            //    .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            //modelBuilder.Entity<ProductCategory>()
            //    .HasOne(pc => pc.Product)
            //    .WithMany(p => p.ProductCategories)
            //    .HasForeignKey(pc => pc.ProductId);

            //modelBuilder.Entity<ProductCategory>()
            //    .HasOne(pc => pc.Category)
            //    .WithMany(c => c.ProductCategories)
            //    .HasForeignKey(pc => pc.CategoryId);

            //modelBuilder.Entity<Product>()
            //    .HasMany(pc => pc.Categories)
            //    .WithMany(c => c.Products)
            //.HasForeignKey(pc => pc.)
            ;

            //.OnDelete(DeleteBehavior.Cascade);
        }

    }
}
