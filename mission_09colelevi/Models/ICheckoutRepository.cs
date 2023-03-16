using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_09colelevi.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkout { get; }

        public void SaveCheckout(Checkout ch);
    }
}
