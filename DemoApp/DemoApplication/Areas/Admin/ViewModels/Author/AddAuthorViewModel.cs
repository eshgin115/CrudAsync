namespace DemoApplication.Areas.Admin.ViewModels.Author
{
    public class AddAuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public AddAuthorViewModel( string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
        public AddAuthorViewModel()
        {

        }
    }
}
