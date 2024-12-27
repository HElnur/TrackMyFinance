using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Domain.Entities;

namespace TrackMyFinance.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Domain.Entities.Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
