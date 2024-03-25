using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace ShoppingCart.Infrastructure.Components
{
        public class SmallCartViewComponent : ViewComponent
        {
                public IViewComponentResult Invoke()
                {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
         //for generic version (1)
         // List<CartItem> cart = HttpContext.Session.GetJ<List<CartItem>>("Cart");


            SmallCartViewModel smallCartVM;

                        if (cart == null || cart.Count == 0)
                        {
                                smallCartVM = null;
                        }
                        else
                        {
                                smallCartVM = new()
                                {
                                        NumberOfItems = cart.Sum(x => x.Quantity),
                                        TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                                };
                        }

                        return View(smallCartVM);
                }
        }
}
