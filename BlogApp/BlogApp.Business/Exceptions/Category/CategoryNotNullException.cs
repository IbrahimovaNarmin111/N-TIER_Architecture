using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Category
{
   public class CategoryNotNullException:Exception
    {
        public CategoryNotNullException() : base("Category bos ola bilmez") { }
        public CategoryNotNullException(string message) : base(message) { }
    }
}
