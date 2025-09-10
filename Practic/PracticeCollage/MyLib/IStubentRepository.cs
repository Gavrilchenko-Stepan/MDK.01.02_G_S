using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public interface IStubentRepository
    {
        Student GetStudentID(int id);
        void SaveStudent(Student student);
    }
}
