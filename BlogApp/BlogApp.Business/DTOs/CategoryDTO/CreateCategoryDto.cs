using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTO
{
   public record CreateCategoryDto
    {
        public string? Name { get; set; }
        
    }
    public class CreateCategoryDtoValidation:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name bos ola bilmez")
                .MaximumLength(55)
                .WithMessage("Uzunlugu 55den cox ola bilmez");
        }

    }
}
