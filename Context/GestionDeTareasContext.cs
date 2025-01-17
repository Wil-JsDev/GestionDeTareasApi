﻿using GestionDeTareasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareasApi.Context
{
    public class GestionDeTareasContext : DbContext
    { 
        public GestionDeTareasContext(DbContextOptions<GestionDeTareasContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>().ToTable("Tasks");

            modelBuilder.Entity<TaskItem>(task =>
            { 
                task.Property(x => x.Description)
                    .HasMaxLength(maxLength: 70)
                    .IsRequired();

                task.Property(x => x.Status)
                    .IsRequired(); 
            });

        }
    }
}
