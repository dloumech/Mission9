using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        //constructor
        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book); //purchase AND book info

        public void SavePurchase(Purchase purchases)
        {
            context.AttachRange(purchases.Lines.Select(x => x.Book));

            if(purchases.PurchaseId == 0)
            {
                context.Purchases.Add(purchases);
            }

            context.SaveChanges();
        }
    }
}
