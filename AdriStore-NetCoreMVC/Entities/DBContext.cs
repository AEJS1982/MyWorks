using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADRISTORE.BE
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<Catalogo> Catalogo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<PedidoCab> PedidoCab { get; set; }
        public virtual DbSet<PedidoDet> PedidoDet { get; set; }
        public virtual DbSet<RubroCatalogo> RubroCatalogo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Config.CnxStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Precio).HasColumnType("NUMERIC");

                entity.HasOne(d => d.Rubro)
                    .WithMany(p => p.Catalogo)
                    .HasForeignKey(d => d.RubroId);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dni).HasColumnName("DNI");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatalogoId).HasColumnName("CatalogoID");

                entity.HasOne(d => d.Catalogo)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.CatalogoId);
            });

            modelBuilder.Entity<PedidoCab>(entity =>
            {
                entity.ToTable("PedidoCAB");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Total).HasColumnType("NUMERIC");

                /*entity.HasOne(d => d.cliente)
                   .WithMany(p => p.Pedidos)
                   .HasForeignKey(d => d.ClienteId);*/
            });

            modelBuilder.Entity<PedidoDet>(entity =>
            {
                entity.ToTable("PedidoDET");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Subtotal).HasColumnType("NUMERIC");

                entity.HasOne(d => d.PedidoCab)
                    .WithMany(p => p.PedidoDet)
                    .HasForeignKey(d => d.PedidoCabId);
            });

            modelBuilder.Entity<RubroCatalogo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.TipoUsuario).HasColumnType("NUMERIC");
            });
        }
    }
}
