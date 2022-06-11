using HotelListing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}
