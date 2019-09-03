using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<MakeEntity> VehicleMakes { get; set; }
        public DbSet<ModelEntity> VehicleModels { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MakeEntity>().ToTable("VehicleMakes");
            builder.Entity<MakeEntity>().HasKey(p => p.Id);
            builder.Entity<MakeEntity>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<MakeEntity>().Property(p=>p.Id).IsRequired();
            builder.Entity<MakeEntity>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<MakeEntity>().Property(p => p.Abrv).IsRequired().HasMaxLength(15);
            builder.Entity<MakeEntity>().HasMany(p => p.VehicleModels).WithOne(p => p.VehicleMake).HasForeignKey(p => p.VehicleMakeId);

            builder.Entity<MakeEntity>().HasData
                (
                new MakeEntity { Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-0800200c9a66"), Name = "VolksWagen", Abrv = "VW" },
                new MakeEntity { Id = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66"), Name = "Bmw", Abrv = "BMW" }
                );

            builder.Entity<ModelEntity>().ToTable("VehicleModels");
            builder.Entity<ModelEntity>().HasKey(p => p.Id);
            builder.Entity<ModelEntity>().Property(p => p.Id).IsRequired();
            builder.Entity<ModelEntity>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<ModelEntity>().Property(p => p.Abrv).IsRequired().HasMaxLength(15);
            builder.Entity<ModelEntity>().Property(p => p.VehicleMakeId).IsRequired();

            builder.Entity<ModelEntity>().HasData
               (
               new ModelEntity { Id = Guid.NewGuid(), Name = "Golf 3", Abrv = "G3", VehicleMakeId = Guid.Parse("2ca5ebe0-9b49-11e9-b475-0800200c9a66") },
               new ModelEntity { Id = Guid.NewGuid(), Name = "x3", Abrv = "X3", VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66") }

               )
               ;

        }
    }
}
