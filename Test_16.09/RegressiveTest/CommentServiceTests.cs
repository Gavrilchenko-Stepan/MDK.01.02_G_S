using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyLib;

namespace RegressiveTest
{
    [TestClass]
    public class CommentServiceTests
    {
        [TestMethod]
        public void AddComment_UserExists_CommentAdded()
        {
            var mockCommentRepo = new Mock<ICommentRepository>();
            var mockUserService = new Mock<IUserService>();

            var commentService = new CommentService(mockCommentRepo.Object, mockUserService.Object);
            var user = new User { Id = 1, Name = "Генадий ГОрин" };

            mockUserService.Setup(x => x.UserExists(1)).Returns(true);
            mockUserService.Setup(x => x.GetUser(1)).Returns(user);

            var result = commentService.AddComment(1, "Шо вы делаете в моём холодильнике, вы хотети кушац?");

            Assert.IsNotNull(result);
            Assert.AreEqual("Шо вы делаете в моём холодильнике, вы хотети кушац?", result.Text);
            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual("Генадий ГОрин", result.User.Name);

            mockCommentRepo.Verify(x => x.AddComment(It.IsAny<Comment>()), Times.Once);
        }
    }
}
