using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Subscribe
{
    public class AddViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
