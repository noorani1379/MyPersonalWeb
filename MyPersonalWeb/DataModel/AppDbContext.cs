using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.Models;
using System.Data;

namespace MyPersonalWeb.DataModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        //    foreach (var fk in cascadeFKs)
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
