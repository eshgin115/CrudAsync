using DemoApplication.Areas.Admin.ViewModels.Subscribe;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/Subscribe")]
    public class SubscribeController : Controller
    {
        private readonly DataContext _dbContext;

        public SubscribeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

     

        [HttpGet("list", Name = "Subscribe-list")]
        public ActionResult List()
        {
            var model = _dbContext.Subscribes
                .Select(b => new ListSubscribeViewModel(b.Id, b.Email, b.CreatedAt, b.UpdatedAt))
                .ToList();

            return View(model);
        }
    }
}