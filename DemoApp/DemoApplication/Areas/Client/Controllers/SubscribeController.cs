using DemoApplication.Areas.Client.ViewModels.Subscribe;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("subscribe")]
    public class SubscribeController : Controller
    {
        private readonly DataContext _dbContext;

        public SubscribeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpPost("add", Name = "subscribe-add")]
        public async Task<ActionResult> AddAsync([FromBody] AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           await _dbContext.Subscribes.AddAsync(new Subscribe
            {
                Email = model.Email,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            });
           await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
