﻿using Gifter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Data
{
    public class ApplicationData
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<UserProfile> UserProfile { get; set; }
            public DbSet<Post> Post { get; set; }
        }
    }
}
