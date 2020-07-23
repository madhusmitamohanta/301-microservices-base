using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MT.OnlineRestaurant.DataLayer.Context
{
    public class ReviewManagementContext:DbContext
    {

        private readonly string DbConnectionString;
        public ReviewManagementContext()
        {
        }

        public ReviewManagementContext(DbContextOptions<ReviewManagementContext> options) : base(options)
        {
        }

        public ReviewManagementContext(string connectionstring)
        {
            DbConnectionString = connectionstring;
        }

        public virtual DbSet<LoggingInfo> LoggingInfo { get; set; }
       
        public virtual DbSet<TblTableReview> TblTableReview { get; set; }
        public virtual DbSet<TblTableRating> TblTableRating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=tcp:capstoneteam1server.database.windows.net,1433;Initial Catalog=OrderManagement;Persist Security Info=False;user id=cpadmin;password=Mindtree@12;");
               // optionsBuilder.UseSqlServer(DbConnectionString);
                optionsBuilder.UseSqlServer("Server=vs2019vm\\SQLEXPRESS;Initial Catalog=ReviewManagement;Persist Security Info=False;Integrated security=True;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<LoggingInfo>(entity =>
            {
                entity.Property(e => e.ActionName)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description).HasDefaultValueSql("('')");

                entity.Property(e => e.RecordTimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblTableReview>(entity =>
            {
                entity.ToTable("tblReview");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TblRatingId)
                    .HasColumnName("TblRatingId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TblRestaurantId)
                    .HasColumnName("TblRestaurantId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TblUserId)
                    .HasColumnName("TblUserId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBy")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedBy)
                   .HasColumnName("UpdatedBy")
                    .HasDefaultValueSql("('')");

              
            });

            modelBuilder.Entity<TblTableRating>(entity =>
               {
                   entity.ToTable("tblRating");

                   entity.Property(e => e.Id).HasColumnName("ID");

                   entity.Property(e => e.Rating)
                       .IsRequired()
                       .HasDefaultValueSql("('')");

               }

            );
        }
    }
}
