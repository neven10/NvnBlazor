using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NvnBlazor.App.Models
{
    public partial class DbNevenBlazorContext : DbContext
    {
        public DbNevenBlazorContext()
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        public DbNevenBlazorContext(DbContextOptions<DbNevenBlazorContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database="";Trusted_Connection=True;MultipleActiveResultSets=true");
            //            }

            optionsBuilder.UseSqlite("Data source=blazorLocalDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
