﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services;

#nullable disable

namespace Services.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220622095625_Initialdb3")]
    partial class Initialdb3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserIdNum")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Last")
                        .HasColumnType("longtext");

                    b.Property<string>("Lastdate")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id", "UserIdNum");

                    b.HasIndex("UserIdNum");

                    b.ToTable("Contactsdb");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ContactIdNum")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserIdNum1")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Created")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Sent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id", "ContactIdNum", "UserIdNum1");

                    b.HasIndex("ContactIdNum", "UserIdNum1");

                    b.ToTable("Messagesdb");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usersdb");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany("Contacts")
                        .HasForeignKey("UserIdNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.HasOne("Domain.Contact", null)
                        .WithMany("ChatWithContact")
                        .HasForeignKey("ContactIdNum", "UserIdNum1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Navigation("ChatWithContact");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
