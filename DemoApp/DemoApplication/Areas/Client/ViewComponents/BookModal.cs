using DemoApplication.Areas.Client.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.ViewComponents
{
    public class BookModal:ViewComponent
    {
        public IViewComponentResult Invoke(ModelViewModel model)
        {
            return View(model);
        }
    }
}
