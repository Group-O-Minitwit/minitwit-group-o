﻿using Microsoft.EntityFrameworkCore;
using Minitwit7.Models;

namespace Minitwit7.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Follower> Followers => Set<Follower>();
        public DbSet<Message> Messages => Set<Message>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.Property<int>("UserId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                e.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("TEXT");

                e.Property<string>("PwHash")
                    .IsRequired()
                    .HasColumnType("TEXT");

                e.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("TEXT");

                e.HasKey(x => x.UserId);

                e.ToTable("Users");
            });

            modelBuilder.Entity<Message>(b =>
            {
                b.Property<int>("MessageId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("AuthorId")
                    .HasColumnType("TINTEGER");

                b.Property<int>("Flagged")
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("PubDate")
                    .HasColumnType("Date");

                b.Property<string>("text")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.HasKey("MessageId");

                b.ToTable("Messages");
            });

            modelBuilder.Entity<Follower>(b =>
            {
                b.Property<int>("UserId")
                    .HasColumnType("INTEGER");

                b.Property<int>("FollowsId")
                    .HasColumnType("INTEGER");

                b.HasKey(x => new { x.UserId, x.FollowsId });

                b.ToTable("Followers");
            });
        }

    }
}
