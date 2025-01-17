﻿// <auto-generated />
using System;
using EmpirePersonellLedger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpirePersonellLedger.Migrations
{
    [DbContext(typeof(EmpireDbContext))]
    partial class EmpireDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpirePersonellLedger.Trooper", b =>
                {
                    b.Property<int>("TrooperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nick")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrooperTypeTypeName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TrooperId");

                    b.HasIndex("TrooperTypeTypeName");

                    b.ToTable("Troopers");
                });

            modelBuilder.Entity("EmpirePersonellLedger.TrooperType", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeName");

                    b.ToTable("TrooperTypes");
                });

            modelBuilder.Entity("EmpirePersonellLedger.Trooper", b =>
                {
                    b.HasOne("EmpirePersonellLedger.TrooperType", "TrooperType")
                        .WithMany()
                        .HasForeignKey("TrooperTypeTypeName");

                    b.Navigation("TrooperType");
                });
#pragma warning restore 612, 618
        }
    }
}
