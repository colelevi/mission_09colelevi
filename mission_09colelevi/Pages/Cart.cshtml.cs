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

        public CartModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        
        // bask model
        public Basket basket { get; set; }
        
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnURL)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnURL = returnURL });
        }

        public IActionResult OnPostRemove(int bookId, string returnURL)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
