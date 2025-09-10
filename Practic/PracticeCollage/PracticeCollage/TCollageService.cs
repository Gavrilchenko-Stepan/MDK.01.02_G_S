using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyLib;
using System;
using System.Collections.Generic;

namespace PracticeCollage
{
    [TestClass]
    public class TCollageService
    {
        [TestMethod]
        public void EnrollStudent()
        {
            var studentRepoMock = new Mock<IStudentRepository>();
            var groupRepoMock = new Mock<IGroupRepository>();

            studentRepoMock.Setup(r => r.GetStudentID(1)).Returns(new Student { Id = 1, Name = "Гриша" });
            groupRepoMock.Setup(r => r.GetGroup(1)).Returns(new Group
            {
                Id = 1,
                Name = "ИТ-101",
                MaxStudents = 25,
                Students = new List<Student>()
            });

            var service = new CollageService(studentRepoMock.Object, groupRepoMock.Object);

            var result = service.EnrollStudent(1, 1);

            Assert.AreEqual("Студент зачислен", result);

            studentRepoMock.Verify(r => r.GetStudentID(1), Times.Once);
            groupRepoMock.Verify(r => r.GetGroup(1), Times.Once);
            groupRepoMock.Verify(r => r.UpdateGroup(It.IsAny<Group>()), Times.Once);

        }
    }
}
