using DemoApplication.Areas.Admin.ViewComponets;
using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("list", Name = "admin-author-list")]
        public IActionResult List()
        {
            var model = _dataContext.Authors
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }
        [HttpPost("add", Name = "admin-author-add")]
        public async Task<ActionResult> AddAsync(AddAuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewComponent = ViewComponent(nameof(ModalAdd), model);
                viewComponent.StatusCode = (int)HttpStatusCode.BadRequest;
                return viewComponent;
            }


            await _dataContext.Authors.AddAsync(new Author
            {
                FirstName = model.Name,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            });
            await _dataContext.SaveChangesAsync();

            var listviewComponent= ViewComponent(nameof(ListView));
            listviewComponent.StatusCode = (int)HttpStatusCode.Created;
            return listviewComponent;
        }
        [HttpGet("update/{id}", Name = "author-update")]
        public async Task<ActionResult> GetModelAsync(int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);


            if (author is null) return NotFound();




            var model = new UpdateViewModel(author.Id,author.FirstName, author.LastName);

            return ViewComponent(nameof(ModalUpdate),model);
        }
        [HttpPut("update/{id}", Name = "admin-author-updateAsync")]
        public async Task<ActionResult> Update(int id,[FromBody]UpdateViewModel model)
        {
            //var author = _dataContext.Authors.FirstOrDefault(a => a.Id == id);
            

            //if (author is null) return NotFound();

            if (!ModelState.IsValid)
            {
                var viewComponent = ViewComponent(nameof(ModalUpdate), model);
                viewComponent.StatusCode = (int)HttpStatusCode.BadRequest;
                return viewComponent;
            }

            //author.FirstName = model.Name;
            //author.LastName = model.LastName;
            //author.UpdatedAt = DateTime.Now;

            await _dataContext.SaveChangesAsync();


            return ViewComponent(nameof(ListView));
        }
        [HttpDelete("delete/{id}", Name = "admin-author-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null) return NoContent();

            _dataContext.Authors.Remove(author);
            await _dataContext.SaveChangesAsync();

            return ViewComponent(nameof(ListView));
        }
    }
}
