using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTO
{
    public class UpdateCategoryDto
    {
         public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Image { get; set; }
    }
}
