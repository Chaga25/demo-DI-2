using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_DI
{
    public class User : IUserEntity
    {
        public string Ping()
        {
            return "User Ping!";
        }
    }
}
