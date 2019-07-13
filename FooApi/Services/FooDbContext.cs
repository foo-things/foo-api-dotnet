using Microsoft.EntityFrameworkCore;
using FooApi.Entities;

namespace FooApi.Services
{
    public class FooDbContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }
        public DbSet<OtherThing> OtherThings { get; set; }

        public FooDbContext(
             DbContextOptions<FooDbContext> options)
             : base(options)
        {
        }
    }
}
