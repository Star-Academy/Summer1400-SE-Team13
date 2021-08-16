﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Search.Model;

namespace Search.Migrations
{
    [DbContext(typeof(SearchContext))]
    [Migration("20210816131008_InvertedIndex")]
    partial class InvertedIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocWord", b =>
                {
                    b.Property<string>("DocsName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WordsContent")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DocsName", "WordsContent");

                    b.HasIndex("WordsContent");

                    b.ToTable("RelationTable");
                });

            modelBuilder.Entity("Search.Model.Doc", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("Search.Model.Word", b =>
                {
                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Content");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("DocWord", b =>
                {
                    b.HasOne("Search.Model.Doc", null)
                        .WithMany()
                        .HasForeignKey("DocsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Search.Model.Word", null)
                        .WithMany()
                        .HasForeignKey("WordsContent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
