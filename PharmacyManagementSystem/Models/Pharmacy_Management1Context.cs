using Microsoft.EntityFrameworkCore;


#nullable disable
namespace PharmacyManagementSystem.Models
{
    public partial class Pharmacy_Management1Context : DbContext
    {
        public Pharmacy_Management1Context()
        {
        }

        public Pharmacy_Management1Context(DbContextOptions<Pharmacy_Management1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DrugDetail> DrugDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Pharmacy_Management1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugDetail>(entity =>
            {
                entity.HasKey(e => e.DrugId)
                    .HasName("PK__DrugDeta__908D66167F499E59");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DrugName).HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.DrugDetails)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__DrugDetai__Suppl__286302EC");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.UserId })
                    .HasName("PK__Orders__12E8D70B1ACC42BC");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderId__300424B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__30F848ED");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BCFA8C314B0");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickedUp).HasColumnType("datetime");

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.DrugId)
                    .HasConstraintName("FK__OrderDeta__DrugI__2B3F6F97");
            });

            modelBuilder.Entity<SupplierDetail>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__Supplier__4BE666B420F6F540");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierContact).HasMaxLength(100);

                entity.Property(e => e.SupplierEmail).HasMaxLength(255);

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C344B0210");

                entity.Property(e => e.Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserAddress).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.UserPassword).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
