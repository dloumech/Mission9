using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Basket
    {
        //The cart should update the quantity, price, subtotal,
        //and total for each book that is added.The information should persist in
        //the cart for the duration of the session.
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book bo, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price); //times price

            return sum;
        }
    }

    

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
