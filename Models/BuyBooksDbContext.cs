using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuyBooks.Models
{
    public class BuyBooksDbContext : DbContext
    {
        //Constructor
        public BuyBooksDbContext (DbContextOptions<BuyBooksDbContext> options) : base (options)
        {

        }
        
        public DbSet<Library> Libraries { get; set; }
    }
}
