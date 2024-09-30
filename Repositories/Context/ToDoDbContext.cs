using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Context
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoListModel> ToDos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoListModel>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<ToDoListModel>().Property(t => t.IsCompleted).IsRequired();
            modelBuilder.Entity<ToDoListModel>().Property(t => t.DueDate).IsRequired();
        }

    }
}
