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
            List<string> students = new List<string> { "Илья Курчин", "Дмитрий Булкин", "Василий Куролесов", "Алла Пугачёва" };
            college.AddGroup(NameGroup, students);

            string NameGroup2 = "М-30";
            List<string> students2 = new List<string> { "Анна Светлова", "Светлана Соколова", "Кирилл Дудкин", "Антон Петров" };
            college.AddGroup(NameGroup2, students2);

            string NameGroup3 = "П-40";
            List<string> students3 = new List<string> { "Максим Галкин", "Катерина Смирнова", "Алексей Чумаков" };
            college.AddGroup(NameGroup3, students3);

            string nonexistentGroup = "М-30";
            List<string> result = college.GetStudentGroup(nonexistentGroup);
            Assert.IsTrue(result.Count == 0, "Ожидалось, что список будет пустым, так как группа не существует.");

            List<string> Studentsget = college.GetStudentGroup(NameGroup);
            CollectionAssert.AreEqual(students, Studentsget);

            List<string> Studentsget2 = college.GetStudentGroup(NameGroup2);
            CollectionAssert.AreEqual(students2, Studentsget2);

            List<string> Studentsget3 = college.GetStudentGroup(NameGroup3);
            CollectionAssert.AreEqual(students3, Studentsget3);

            
        }
    }
}
