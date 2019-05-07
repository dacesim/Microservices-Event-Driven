﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ordering.Infrastructure.Data;

namespace Ordering.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190506071502_AddDispatchIdColumnInOrderTable")]
    partial class AddDispatchIdColumnInOrderTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ordering.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("DispatchId")
                        .HasColumnName("dispatch_id");

                    b.Property<string>("OrderStatus")
                        .HasColumnName("order_status");

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Ordering.Models.OrderLineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_line_item");
                });

            modelBuilder.Entity("Ordering.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ProductName")
                        .HasColumnName("product_name");

                    b.Property<double>("UnitPrice")
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductName = "Apple",
                            UnitPrice = 90.0
                        },
                        new
                        {
                            Id = 2,
                            ProductName = "Orange",
                            UnitPrice = 15.300000000000001
                        },
                        new
                        {
                            Id = 3,
                            ProductName = "Banana",
                            UnitPrice = 3.5
                        });
                });

            modelBuilder.Entity("Ordering.Models.OrderLineItem", b =>
                {
                    b.HasOne("Ordering.Models.Order")
                        .WithMany("OrderLineItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("Ordering.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
