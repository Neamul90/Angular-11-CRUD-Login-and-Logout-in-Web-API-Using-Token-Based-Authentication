using Microsoft.EntityFrameworkCore;
using PortfulioWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfulioWebsite
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
