using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBooks.Models
{
    public class EFBuyBooksRepository : IBuyBooksRepository
    {
        private BuyBooksDbContext _context;

        //Constructor
        public EFBuyBooksRepository (BuyBooksDbContext context)
        {
            //set private context to the context variable
            _context = context;
        }

        //Passes the context from Libraries
        public IQueryable<Library> Libraries => _context.Libraries;
    }
}
