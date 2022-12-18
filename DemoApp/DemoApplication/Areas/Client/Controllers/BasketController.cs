using DemoApplication.Areas.Client.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("basket")]
    public class BasketController : Controller
    {
        private readonly DataContext _dataContext;

        public BasketController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("add-basket/{id}", Name = "client-basket-add")]
        public async Task<ActionResult> AddAsync([FromRoute] int id)
        {
            var book = _dataContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is null) NotFound();
            var model = new List<AddCokiesValue>();
      

            var cookieValue = HttpContext.Request.Cookies["products"];
            if (cookieValue is null)
            {
                model = new List<AddCokiesValue>(){
                    new AddCokiesValue(book.Id, book.Title, string.Empty, 1, book.Price, book.Price) };
                HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(model));
            }
            else
            {
                model = JsonSerializer.Deserialize<List<AddCokiesValue>>(cookieValue);
                var targetmodel = model.FirstOrDefault(model => model.Id == id);
                if (targetmodel is null)
                {
                    model.Add(new AddCokiesValue(book.Id, book.Title, string.Empty, 1, book.Price, book.Price));
                    HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(model));
                }
                else
                {
                    targetmodel.Count += 1;
                    targetmodel.Total = targetmodel.Count * targetmodel.Price;
                    HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(model));

                }
            }
         

            return ViewComponent(nameof(ShopCart),model);
        }

        [HttpGet("Delete-basket/{id}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cookieViewModel = HttpContext.Request.Cookies["products"];
            if (cookieViewModel is null) return NotFound();
            var model = JsonSerializer.Deserialize<List<AddCokiesValue>>(cookieViewModel);
            var targetmodel = model.FirstOrDefault(model => model.Id == id);
            if (targetmodel is null) return NotFound();
            if (targetmodel.Count == 1)
            {
                model.Remove(targetmodel);

            }
            else
            {
                targetmodel.Count -= 1;
                targetmodel.Total = targetmodel.Count * targetmodel.Price;


            }
            HttpContext.Response.Cookies.Append("products", JsonSerializer.Serialize(model));
            return ViewComponent(nameof(ShopCart),model);
        }
    }
}

