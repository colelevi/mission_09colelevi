using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission_09colelevi.Infrustructure;
using mission_09colelevi.Models;

namespace mission_09colelevi.Pages
{
    public class CartModel : PageModel
    {
       private IBookstoreRepository repo { get; set; }
        public string ReturnURL { get; set; }

        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        
        // bask model
        public Basket basket { get; set; }
        
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnURL)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
