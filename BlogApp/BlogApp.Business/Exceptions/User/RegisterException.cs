using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.User
{
    public class RegisterException:Exception
    {
        public RegisterException() : base("Qeydiyyatda problem yasandi") { }
        public RegisterException(string message) : base(message) { }
    }
}
