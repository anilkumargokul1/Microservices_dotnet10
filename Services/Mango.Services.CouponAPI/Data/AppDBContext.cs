using System;
using System.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Coupon> Coupons { get; set; }
}
