using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBooks.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Library library, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Library.BookId == library.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Library = library,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Library library)
        {
            //removes specific item from cart
            Lines.RemoveAll(x => x.Library.BookId == library.BookId);
        }

        //removes all lines from the cart
        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotal()
        {
            //returns the total amount for the cart
            return Lines.Sum(e => e.Library.Price * e.Quantity);
        }


        public class CartLine
        {
            public int CartLineID { get; set; }

            public Library Library { get; set; }

            public int Quantity { get; set; }
        }
           
    }
}
