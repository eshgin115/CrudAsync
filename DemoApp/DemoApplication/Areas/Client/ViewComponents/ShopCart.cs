using DemoApplication.Areas.Client.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.ViewComponents
{
    public class ShopCart : ViewComponent
    {
        public IViewComponentResult Invoke(List<AddCokiesValue> addCokiesValues=null)
        {
            if (addCokiesValues is not null) return View(addCokiesValues);

            var cookieValue = HttpContext.Request.Cookies["products"];

            var ProductsCookieValue = new List<AddCokiesValue>();
            if (cookieValue is not null)
            {
                ProductsCookieValue = JsonSerializer.Deserialize<List<AddCokiesValue>>(cookieValue);
            }


            return View(ProductsCookieValue);
        }
    }
}
