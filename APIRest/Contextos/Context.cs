using APIRest.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Contextos
{
    public partial class Context : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Profesores> Profesores { get; set; }

        public Context(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders", "sales");
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.order_date).HasColumnType("date");
                entity.Property(e => e.required_date).HasColumnType("date");
                entity.Property(e => e.shipped_date).HasColumnType("date");
            });

            modelbuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_items", "sales");
                entity.HasKey(e => new { e.OrderId, e.item_id });
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.discount).HasColumnType("decimal(4,2)");
                entity.Property(e => e.list_price).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Item).WithMany(p => p.OrderItems).HasForeignKey(d => d.product_id);
            });

            modelbuilder.Entity<Item>(entity =>
            {
                entity.ToTable("products", "production");
                entity.HasKey(e => e.product_id);
                entity.Property(e => e.product_name).HasMaxLength(255);
            });
            modelbuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);
                entity.Property(e => e.Nacimiento).HasColumnType("date");
                entity.Property(e => e.Nombre).HasMaxLength(45).IsRequired();
                entity.HasOne(e => e.Curso).WithMany(e => e.Alumnos).HasForeignKey(e => e.IdCurso);
            });

            modelbuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso);
                entity.Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            });

            modelbuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);
                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();

                entity.HasMany(e => e.Cursos).WithOne(e => e.Profesor).HasForeignKey(e => e.IdProfesor);
            });

            OnModelCreatingPartial(modelbuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
