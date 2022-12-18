using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Admin.ViewComponets
{
    public class ModalAdd:ViewComponent
    {
       
        public IViewComponentResult Invoke(AddAuthorViewModel model = null)
        {
            
            return View(model ?? new AddAuthorViewModel());

        }
    }
}
