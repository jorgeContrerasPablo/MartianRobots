using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureEF.Repositories
{
    public partial class MartianContext : DbContext
    {
        public MartianContext(DbContextOptions<MartianContext> options)
            : base(options)
        {            
        }

        public virtual DbSet<Command> Commands { get; set; }

        public virtual DbSet<Direction> Directions { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Robot> Robots { get; set; }

        public virtual DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>(entity =>
            {

                entity.HasKey(e => e.CommandId);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Description)
                .HasMaxLength(255);

            });

            modelBuilder.Entity<Command>().HasData(
                new Command { CommandId = 1, Name = nameof(Command.Type.L), Description = "Move Left" });
            modelBuilder.Entity<Command>().HasData(
                new Command { CommandId = 2, Name = nameof(Command.Type.R), Description = "Move Right" });
            modelBuilder.Entity<Command>().HasData(
                new Command { CommandId = 3, Name = nameof(Command.Type.F), Description = "Move Forward" });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.DirectionId);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Description)
                .HasMaxLength(255);


            });

            modelBuilder.Entity<Direction>().HasData(
                new Direction { DirectionId = 1, Name = nameof(Direction.Type.N), Description = "North" });
            modelBuilder.Entity<Direction>().HasData(
                new Direction { DirectionId = 2, Name = nameof(Direction.Type.S), Description = "South" });
            modelBuilder.Entity<Direction>().HasData(
                new Direction { DirectionId = 3, Name = nameof(Direction.Type.E), Description = "East" });
            modelBuilder.Entity<Direction>().HasData(
                new Direction { DirectionId = 4, Name = nameof(Direction.Type.W), Description = "West" });

            modelBuilder.Entity<Position>(entity =>
            {

                entity.HasKey(e => e.PositionId);

                entity.Property(e => e.X)
                .IsRequired();

                entity.Property(e => e.Y)
                .IsRequired();

                entity.Property(e => e.DirectionId);

                entity.HasOne(e => e.Direction)
                .WithMany(p => p.Positions)
                .HasForeignKey(d => d.DirectionId)
                .HasConstraintName("FK_Position_Direction");

            });
            
            modelBuilder.Entity<Robot>(entity =>
            {
                entity.HasKey(e => e.RobotId);

                entity.Property(e => e.PositionId);

                entity.Property(e => e.CreatedTime);

                entity.HasOne(e => e.Position)
                .WithMany(p => p.Robots)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Robot_Position");


            });
            
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.Property(e => e.PositionId);

                entity.Property(e => e.RobotId);

                entity.Property(e => e.CommandId);                      

                entity.HasOne(e => e.Robot)
                .WithMany(p => p.Routes)
                .HasForeignKey(d => d.RobotId)
                .HasConstraintName("FK_Route_Robot");

                entity.HasOne(e => e.Position)
                .WithMany(p => p.Routes)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Route_Position");

                entity.HasOne(e => e.Command)
                .WithMany(p => p.Routes)
                .HasForeignKey(d => d.CommandId)
                .HasConstraintName("FK_Route_Command");
            });
        }
    }
}
