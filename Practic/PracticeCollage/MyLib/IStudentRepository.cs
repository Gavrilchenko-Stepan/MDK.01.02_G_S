using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public interface IStudentRepository
    {
        Student GetStudentID(int id);
        void SaveStudent(Student student);
    }
}
