using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.UserDTO
{
    public record RegisterDto
    {
        public string Name { get;set; }
        public string Surname { get; set; }
        public string Username { get;set; }
        public string Email { get;set; }    
        public string Password { get;set; } 
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidation:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad bos ola bilmez")
                .MinimumLength(3)
                .WithMessage("Adin uzunlugu 3den kicik ola bilmez")
                .MaximumLength(35)
                .WithMessage("Adin uzunlugu 35den yuxari ola bilmez");

            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage("Soyad bos ola bilmez")
               .MinimumLength(3)
               .WithMessage("Soyadin uzunlugu 3den kicik ola bilmez")
               .MaximumLength(35)
               .WithMessage("Soyadin uzunlugu 35den yuxari ola bilmez");

            RuleFor(x => x.Username)
               .NotEmpty()
               .WithMessage("Username bos ola bilmez")
               .MinimumLength(4)
               .WithMessage("Username uzunlugu 4den kicik ola bilmez")
               .MaximumLength(18)
               .WithMessage("Username uzunlugu 18den yuxari ola bilmez");

            RuleFor(x => x.Email)
              .Must(c =>
              {
                  Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                  Match match = regex.Match(c);
                  return match.Success;
              })
              .WithMessage("Email formatini duzgun daxil edin");

            RuleFor(x => x.Password)
                .Must(p =>
                {
                    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
                    Match match = regex.Match(p);
                    return match.Success;
                })
                .WithMessage("Password formati sehvdir");

            RuleFor(x => x)
                .Must(p => p.ConfirmPassword == p.Password)
                .WithMessage("Passwordlar eyni deyil");
        }
    }
}
