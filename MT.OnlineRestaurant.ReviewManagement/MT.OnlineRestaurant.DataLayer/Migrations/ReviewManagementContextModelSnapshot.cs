﻿// <auto-generated />
using System;
using MT.OnlineRestaurant.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    [DbContext(typeof(ReviewManagementContext))]
    partial class ReviewManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.Context.LoggingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(250);

                    b.Property<string>("ControllerName")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')")
                        .HasMaxLength(250);

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.Property<DateTime?>("RecordTimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('')");

                    b.HasKey("Id");

                    b.ToTable("LoggingInfo");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.Context.TblTableRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.HasKey("Id");

                    b.ToTable("tblRating");
                });

            modelBuilder.Entity("MT.OnlineRestaurant.DataLayer.Context.TblTableReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('')");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreatedBy")
                        .HasDefaultValueSql("('')");

                    b.Property<DateTime?>("CreatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("TblRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TblRatingId")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("TblRestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TblRestaurantId")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("TblUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TblUserId")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("UpdatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UpdatedBy")
                        .HasDefaultValueSql("('')");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("tblReview");
                });
#pragma warning restore 612, 618
        }
    }
}