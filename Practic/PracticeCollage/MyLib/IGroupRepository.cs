using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public interface IGroupRepository
    {
        Group GetGroup(int id);
        void UpdateGroup(Group group);
    }
}
