﻿// <auto-generated />
using System;
using Crm.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crm.DataAccess.Migrations
{
    [DbContext(typeof(CrmDbContex))]
    [Migration("20231024060441_OneToManyRelationship")]
    partial class OneToManyRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Crm.DataAccess.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER")
                        .HasColumnName("age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("first-name");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("last-name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("middle-name");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("passport-name");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("email");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)")
                        .HasColumnName("password");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create-at");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("delivery-address");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("integer")
                        .HasColumnName("delivery-type");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int>("MyOrderState")
                        .HasColumnType("integer")
                        .HasColumnName("order-state");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_id");

                    b.HasIndex("ClientId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Crm.DataAccess.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Crm.DataAccess.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}