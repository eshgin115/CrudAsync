using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Admin.ViewComponets
{
  
    public class ListView : ViewComponent
    {
        private readonly DataContext _dataContext;

        public ListView(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke(List<ListItemViewModel>? models =null)
        {
            if (models is not null) return View(models);


            var modelAuthors = _dataContext.Authors
               .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
               .ToList();


            return View(modelAuthors);
        }
    }
}
