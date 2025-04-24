using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
     
            public DbSet<Ticket> Tickets { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Priority> Priorities { get; set; }
            public DbSet<Discussion> Discussions { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Attachment> Attachments { get; set; }

            // Optional: OnModelCreating and constructor can go here

            protected override void OnModelCreating(ModelBuilder builder) {
                base.OnModelCreating(builder);
            builder.GenerateSeed();
             
                // Ticket → User (Many tickets can be raised by one User)
                builder.Entity<Ticket>()
                    .HasOne(e => e.User)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);

                // Discussion → Ticket (Many discussions belong to one Ticket)
                builder.Entity<Discussion>()
                    .HasOne(m => m.Ticket)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
            }

        }
    }


    

