using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission_09colelevi.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission_09colelevi.Models
{
    public class SessionBasket :Basket
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        // return basket from session or make new object
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket sessionBasket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            sessionBasket.Session = session;

            return sessionBasket;
        }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
