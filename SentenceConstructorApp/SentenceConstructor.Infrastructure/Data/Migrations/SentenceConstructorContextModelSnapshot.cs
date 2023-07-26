﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SentenceConstructor.Infrastructure.Data;

#nullable disable

namespace SentenceConstructor.Infrastructure.Data.Migrations
{
    [DbContext(typeof(SentenceConstructorContext))]
    partial class SentenceConstructorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SentenceConstructor.Core.Entities.Sentence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Expression")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("SentenceConstructor.Core.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordTypeId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("SentenceConstructor.Core.Entities.WordType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WordTypes");
                });

            modelBuilder.Entity("SentenceConstructor.Core.Entities.Word", b =>
                {
                    b.HasOne("SentenceConstructor.Core.Entities.WordType", "WordType")
                        .WithMany()
                        .HasForeignKey("WordTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WordType");
                });
#pragma warning restore 612, 618
        }
    }
}
