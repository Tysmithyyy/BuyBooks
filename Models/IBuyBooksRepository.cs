using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBooks.Models
{
    public interface IBuyBooksRepository
    {
        IQueryable<Library> Libraries { get; }
    }
}
