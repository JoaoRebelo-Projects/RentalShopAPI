using Microsoft.EntityFrameworkCore;
using RentalShopRepository.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Context
{
    public class RentalShopContext : DbContext
    {
        private const string DECIMAL_TYPE = "decimal(12,2)";

        public RentalShopContext(DbContextOptions<RentalShopContext> options) : base(options)
        {
            Database.Migrate();
        }

        #region Employee Entities

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<PermissionLevel> PermissionLevel { get; set; }
        public DbSet<Role> Role { get; set; }

        #endregion

        #region Member Entities

        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<MembershipAssignment> MembershipAssignment { get; set; }

        #endregion

        #region Product Entities

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductAssignment> ProductAssignment { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        #endregion

        #region File Entities

        public DbSet<Image> Image { get; set; }
        public DbSet<ImageFolder> ImageFolder { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Database Configuration

            #region Role Configurations

            modelBuilder.Entity<Role>()
                .HasOne(a => a.EmployeePermission)
                .WithMany(b => b.EmployeePermissionRoles)
                .HasForeignKey(a => a.EmployeePermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(a => a.MemberPermission)
                .WithMany(b => b.MemberPermissionRoles)
                .HasForeignKey(a => a.MemberPermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(a => a.ProductPermission)
                .WithMany(b => b.ProductPermissionRoles)
                .HasForeignKey(a => a.ProductPermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasOne(a => a.ProductAssignmentPermission)
                .WithMany(b => b.ProductAssignmentPermissionRoles)
                .HasForeignKey(a => a.ProductAssignmentPermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Employee Configuration

            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Role)
                .WithMany(b => b.Employees)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(a => a.HierarchialSuperior)
                .WithMany(b => b.HierarchialSubordinates)
                .HasForeignKey(a => a.HierarchialSuperiorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Photo)
                .WithOne(b => b.EmployeePhoto)
                .HasForeignKey<Employee>(a => a.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasIndex(a => a.Email)
                .IsUnique();

            #endregion

            #region Login Configuration

            modelBuilder.Entity<Login>()
                .HasOne(a => a.Employee)
                .WithOne(b => b.Login)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Image Configuration

            modelBuilder.Entity<Image>()
                .HasOne(a => a.ImageFolder)
                .WithMany(b => b.Images)
                .HasForeignKey(a => a.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Product Configuration

            modelBuilder.Entity<Product>()
                .HasOne(a => a.Image)
                .WithOne(b => b.ProductImage)
                .HasForeignKey<Product>(a => a.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(a => a.ProductType)
                .WithMany(b => b.Products)
                .HasForeignKey(a => a.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Product Type Configuration

            modelBuilder.Entity<ProductType>()
                .HasOne(a => a.Image)
                .WithOne(b => b.ProductTypeIcon)
                .HasForeignKey<ProductType>(a => a.IconId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Product Assignment Configuration

            modelBuilder.Entity<ProductAssignment>()
                .HasOne(a => a.Product)
                .WithMany(b => b.Assignments)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductAssignment>()
                .HasOne(a => a.Member)
                .WithMany(b => b.ProductAssignments)
                .HasForeignKey(a => a.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Member Configuration

            modelBuilder.Entity<Member>()
                .HasOne(a => a.Membership)
                .WithMany(b => b.Members)
                .HasForeignKey(a => a.MembershipId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Membership Configuration

            modelBuilder.Entity<Membership>()
                .Property(a => a.MonthlySubscriptionValue)
                .HasColumnType(DECIMAL_TYPE);

            #endregion

            #endregion

            #region Data Initialization

            #region PermissionLevel Data

            modelBuilder.Entity<PermissionLevel>().HasData(
                new PermissionLevel
                {
                    Id = 1,
                    Name = "ADMIN"
                },
                new PermissionLevel
                {
                    Id = 2,
                    Name = "WRITE"
                },
                new PermissionLevel
                {
                    Id = 3,
                    Name = "READ"
                },
                new PermissionLevel
                {
                    Id = 4,
                    Name = "DENIED"
                });

            #endregion

            #region Role Data

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    EmployeePermissionId = 1,
                    MemberPermissionId = 1,
                    ProductAssignmentPermissionId = 1,
                    ProductPermissionId = 1
                },
                new Role
                {
                    Id = 2,
                    Name = "Manager",
                    EmployeePermissionId = 2,
                    MemberPermissionId = 2,
                    ProductAssignmentPermissionId = 2,
                    ProductPermissionId = 2
                    
                });

            #endregion

            #region Employee Data

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(1991, 04, 10),
                    Email = "JohnDoe@email.com",
                    Phone = "123456789",
                    RoleId = 1,
                    CreatedAt = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mitchell Connor",
                    FirstName = "Mitchell",
                    LastName = "Connor",
                    BirthDate = new DateTime(1992, 07, 11),
                    Email = "MitchellConnor@email.com",
                    Phone = "987654321",
                    RoleId = 2,
                    CreatedAt = DateTime.Now
                });

            #endregion

            #endregion
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).ModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
