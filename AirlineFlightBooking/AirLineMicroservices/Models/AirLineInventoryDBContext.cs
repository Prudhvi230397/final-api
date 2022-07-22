using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirLineMicroservices.Models
{
    public partial class AirLineInventoryDBContext : DbContext
    {
        public AirLineInventoryDBContext()
        {
        }

        public AirLineInventoryDBContext(DbContextOptions<AirLineInventoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirLine> AirLines { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:flightinventory.database.windows.net,1433;Initial Catalog=AirLineInventoryDB;Persist Security Info=False;User ID=flight;Password=Prudhvi@230397;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirLine>(entity =>
            {
                entity.ToTable("AirLine");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AirlineLogo)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.AirlineName).HasMaxLength(50);

                entity.Property(e => e.ContactNo).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountCode).HasMaxLength(50);

                entity.Property(e => e.ExpiryDate).HasColumnType("date");
            });

            modelBuilder.Entity<FlightSchedule>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("FlightSchedule");

                entity.Property(e => e.BoardingPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InstrumentUsed)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MealId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ScheduledDaysId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.TicketCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Travelendtime)
                    .HasMaxLength(50)
                    .HasColumnName("travelendtime");

                entity.Property(e => e.Travelstarttime)
                    .HasMaxLength(50)
                    .HasColumnName("travelstarttime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
