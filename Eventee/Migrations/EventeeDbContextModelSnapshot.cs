﻿// <auto-generated />
using System;
using Eventee.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eventee.Migrations
{
    [DbContext(typeof(EventeeDbContext))]
    partial class EventeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Eventee.Entities.Channel", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("IsAllowedInteraction")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsReminderChannel")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("Eventee.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("EventId")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<int>("MinimumAcceptance")
                        .HasColumnType("int");

                    b.Property<ulong>("OwnerId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Eventee.Entities.EventMember", b =>
                {
                    b.Property<ulong>("MemberId")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("MemberId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventMembers");
                });

            modelBuilder.Entity("Eventee.Entities.Member", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Eventee.Entities.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("DestinationId")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReminderTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReminderType")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Eventee.Entities.Role", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("CanCreateEvents")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CanManageEvents")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsAdminRole")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Eventee.Entities.RSVP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Attendance")
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<ulong>("MemberId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("RSVP");
                });

            modelBuilder.Entity("Eventee.Entities.Server", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("EventsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<ulong>("OwnerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("DiscordServers");
                });

            modelBuilder.Entity("Eventee.Entities.Channel", b =>
                {
                    b.HasOne("Eventee.Entities.Server", "Server")
                        .WithMany("Channels")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Eventee.Entities.Event", b =>
                {
                    b.HasOne("Eventee.Entities.Server", "Server")
                        .WithMany("Events")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Eventee.Entities.EventMember", b =>
                {
                    b.HasOne("Eventee.Entities.Event", "Event")
                        .WithMany("EventMembers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventee.Entities.Member", "Member")
                        .WithMany("EventMembers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Eventee.Entities.Member", b =>
                {
                    b.HasOne("Eventee.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Eventee.Entities.Reminder", b =>
                {
                    b.HasOne("Eventee.Entities.Event", "Event")
                        .WithMany("Reminders")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Eventee.Entities.Role", b =>
                {
                    b.HasOne("Eventee.Entities.Server", "Server")
                        .WithMany("Roles")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Eventee.Entities.RSVP", b =>
                {
                    b.HasOne("Eventee.Entities.Event", "Event")
                        .WithMany("Rsvps")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eventee.Entities.Member", "Member")
                        .WithMany("Rsvps")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Eventee.Entities.Event", b =>
                {
                    b.Navigation("EventMembers");

                    b.Navigation("Reminders");

                    b.Navigation("Rsvps");
                });

            modelBuilder.Entity("Eventee.Entities.Member", b =>
                {
                    b.Navigation("EventMembers");

                    b.Navigation("Rsvps");
                });

            modelBuilder.Entity("Eventee.Entities.Server", b =>
                {
                    b.Navigation("Channels");

                    b.Navigation("Events");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
