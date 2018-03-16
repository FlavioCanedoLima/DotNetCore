using Microsoft.AspNetCore.Mvc;
using MVCCore.Models;
using System;

namespace MVCCore.ViewComponets
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = new CartModel()
            {
                AmountItems = new Random().Next(0, 100),
                AmountValue = new Random().Next(0, 100)
            };

            return View(cart);
        }
    }
}
