using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Revas.Areas.AdminRevas.ViewModels
{
    public class CreateVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "File is required")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
    }
}
