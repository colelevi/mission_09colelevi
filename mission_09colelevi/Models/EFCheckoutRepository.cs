using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_09colelevi.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkout => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout ch)
        {
            context.AttachRange(ch.Lines.Select(x => x.Book));

            if (ch.CheckoutId == 0)
            {
                context.Checkout.Add(ch);
            }

            context.SaveChanges();
        }
    }
}
