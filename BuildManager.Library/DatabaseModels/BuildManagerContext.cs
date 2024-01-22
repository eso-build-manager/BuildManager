﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuildManager.Library.DataBaseModels;

public partial class BuildManagerContext : DbContext
{
    public BuildManagerContext(DbContextOptions<BuildManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SetList> SetList { get; set; }

    public virtual DbSet<SetUsableItemSlots> SetUsableItemSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SetList>(entity =>
        {
            entity.HasKey(e => e.SetId);

            entity.ToTable("SetList", "Set");

            entity.Property(e => e.SetId).ValueGeneratedNever();
            entity.Property(e => e.SetBonusDescription).IsUnicode(false);
            entity.Property(e => e.SetName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sources)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.alias).IsUnicode(false);
        });

        modelBuilder.Entity<SetUsableItemSlots>(entity =>
        {
            entity.HasKey(e => e.SetUsableItemSlotId);

            entity.ToTable("SetUsableItemSlots", "Set");

            entity.HasOne(d => d.Set).WithMany(p => p.SetUsableItemSlots)
                .HasForeignKey(d => d.SetId)
                .HasConstraintName("FK__SetUsable__SetId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}