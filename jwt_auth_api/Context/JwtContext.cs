﻿using jwt_auth_api.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt_auth_api.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
