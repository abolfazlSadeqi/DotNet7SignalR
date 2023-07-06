using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts;


public class TestCurdContext : DbContext
{
    public TestCurdContext(DbContextOptions<TestCurdContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}


