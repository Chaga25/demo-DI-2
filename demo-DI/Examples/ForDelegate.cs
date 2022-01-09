using demo_DI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_DI
{
    public class ForDelegate : IForDelegate
    {
        public string SomeMethod()
        {
            return "ForDelegate!";
        }
    }
}
