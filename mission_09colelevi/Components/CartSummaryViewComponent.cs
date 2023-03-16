using Microsoft.AspNetCore.Mvc;
using mission_09colelevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_09colelevi.Components
{
    public class CartSummaryViewComponent :ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
