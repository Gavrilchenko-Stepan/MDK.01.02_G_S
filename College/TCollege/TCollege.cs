using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;
using System.Collections.Generic;

namespace TestCollege
{
    [TestClass]
    public class TCollege
    {
        [TestMethod]
        public void TestGetStudentsGroup()
        {
            College college = new College();
            Student student = new Student();

            string NameGroup = "П-20";
            List<string> students = new List<string> { "Илья", "Булкин" };
            college.AddGroup(NameGroup, students);

            List<string> Studentsget = college.GetStudentGroup(NameGroup);


            CollectionAssert.AreEqual(students, Studentsget);

        }
    }
}
