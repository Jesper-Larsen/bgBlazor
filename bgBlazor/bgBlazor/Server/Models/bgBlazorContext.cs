using System;
using System.Collections.Generic;
using bgBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bgBlazor.Server.Models
{
    public partial class bgBlazorContext : DbContext
    {
        public bgBlazorContext()
        {
        }

        public bgBlazorContext(DbContextOptions<bgBlazorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Elever> Elevers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bgBlazor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elever>(entity =>
            {
                entity.ToTable("Elever");

                entity.Property(e => e.Efternavn).HasMaxLength(50);

                entity.Property(e => e.Fornavn).HasMaxLength(50);

                entity.Property(e => e.KursusType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
