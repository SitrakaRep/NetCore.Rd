﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NetCore.Rd.Data.Context;
using System;

namespace NetCore.Rd.Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180514132306_FirstData")]
    partial class FirstData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Rd.Data.Entities.Apartment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentName");

                    b.Property<int>("ApartmentNumber");

                    b.Property<DateTime>("DateCreation");

                    b.Property<DateTime>("DateEdition");

                    b.Property<int?>("OwnerID");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("NetCore.Rd.Data.Entities.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreation");

                    b.Property<DateTime>("DateEdition");

                    b.Property<string>("FirstName");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("NetCore.Rd.Data.Entities.Apartment", b =>
                {
                    b.HasOne("NetCore.Rd.Data.Entities.Owner", "Owner")
                        .WithMany("Apartments")
                        .HasForeignKey("OwnerID");
                });
#pragma warning restore 612, 618
        }
    }
}
