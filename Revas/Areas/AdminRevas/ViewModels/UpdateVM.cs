using Microsoft.AspNetCore.Http; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace Revas.Areas.AdminRevas.ViewModels
{
    public class UpdateVM
    {
        public string Title { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
