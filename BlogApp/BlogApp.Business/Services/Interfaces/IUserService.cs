using BlogApp.Business.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterDto registerDto);
    }
}
