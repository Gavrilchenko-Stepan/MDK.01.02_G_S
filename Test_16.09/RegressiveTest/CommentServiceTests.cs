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

            // Теперь передаем только ICommentRepository
            var commentService = new CommentService(mockCommentRepo.Object);

            var result = commentService.AddComment(1, "Шо вы делаете в моём холодильнике, вы хотети кушац?");

            Assert.IsNotNull(result);
            Assert.AreEqual("Шо вы делаете в моём холодильнике, вы хотети кушац?", result.Text);
            Assert.AreEqual(1, result.UserId);

            // Проверка на User.Name больше не нужна
            mockCommentRepo.Verify(x => x.AddComment(It.IsAny<Comment>()), Times.Once);
        }


    }
}
