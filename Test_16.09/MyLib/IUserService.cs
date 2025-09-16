using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public interface IUserService
    {
        User GetUser(int userId);
        bool UserExists(int userId);
    }
}
