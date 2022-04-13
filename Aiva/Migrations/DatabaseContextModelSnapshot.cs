﻿// <auto-generated />
using System;
using Aiva.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aiva.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Aiva.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Aiva.Models.ClientAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAddresses");
                });

            modelBuilder.Entity("Aiva.Models.Cook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int?>("KitchenId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("KitchenId");

                    b.ToTable("Cooks");
                });

            modelBuilder.Entity("Aiva.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<int?>("KitchenId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("KitchenId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Aiva.Models.Kitchen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kitchen");
                });

            modelBuilder.Entity("Aiva.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("PromocodeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId");

                    b.HasIndex("PromocodeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Aiva.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Aiva.Models.Promocode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountSum")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Promocodes");
                });

            modelBuilder.Entity("Aiva.Models.ClientAddress", b =>
                {
                    b.HasOne("Aiva.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Aiva.Models.Cook", b =>
                {
                    b.HasOne("Aiva.Models.Kitchen", "Kitchen")
                        .WithMany()
                        .HasForeignKey("KitchenId");

                    b.Navigation("Kitchen");
                });

            modelBuilder.Entity("Aiva.Models.Item", b =>
                {
                    b.HasOne("Aiva.Models.Kitchen", "Kitchen")
                        .WithMany()
                        .HasForeignKey("KitchenId");

                    b.Navigation("Kitchen");
                });

            modelBuilder.Entity("Aiva.Models.Order", b =>
                {
                    b.HasOne("Aiva.Models.ClientAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Aiva.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Aiva.Models.Promocode", "Promocode")
                        .WithMany()
                        .HasForeignKey("PromocodeId");

                    b.Navigation("Address");

                    b.Navigation("Client");

                    b.Navigation("Promocode");
                });

            modelBuilder.Entity("Aiva.Models.OrderItem", b =>
                {
                    b.HasOne("Aiva.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Aiva.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Item");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
