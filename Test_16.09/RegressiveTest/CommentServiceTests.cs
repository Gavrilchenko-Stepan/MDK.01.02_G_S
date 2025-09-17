using System;
using System.Collections.Generic;
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
            Comment savedComment = null;

            mockCommentRepo.Setup(x => x.AddComment(It.IsAny<Comment>()))
                  .Callback<Comment>(comment => savedComment = comment);

            var commentService = new CommentService(mockCommentRepo.Object);

            var result = commentService.AddComment(1, "Шо вы делаете в моём холодильнике, вы хотети кушац?");

            Assert.IsNotNull(result);
            Assert.AreEqual("Шо вы делаете в моём холодильнике, вы хотети кушац?", result.Text);
            Assert.AreEqual(1, result.UserId);

            mockCommentRepo.Verify(x => x.AddComment(It.IsAny<Comment>()), Times.Once);
            //добавить проверку что точно комментарий сохранился в хранилище
            Assert.IsNotNull(savedComment);
            Assert.AreEqual("Шо вы делаете в моём холодильнике, вы хотети кушац?", savedComment.Text);
            Assert.AreEqual(1, savedComment.UserId);
            Assert.AreEqual(result.Text, savedComment.Text);
            Assert.AreEqual(result.UserId, savedComment.UserId);
        }

        [TestMethod]
        public void SearchComments_FindsMatchingComments()
        {
            var mockRepo = new Mock<ICommentRepository>();
            var manager = new CommentService(mockRepo.Object);

            var testComments = new List<Comment>
            {
               new Comment { Id = 1, Text = "Программирование это интересно", UserId = 1 },
               new Comment { Id = 2, Text = "Купил продукты в магазине", UserId = 2 },
               new Comment { Id = 3, Text = "Люблю программировать", UserId = 1 },
               new Comment { Id = 4, Text = "Обычный комментарий", UserId = 3 }
            };

            mockRepo.Setup(x => x.GetAllComments()).Returns(testComments);

            var results = manager.SearchComments("пр");

            Assert.AreEqual(3, results.Count);

            var expectedTexts = new List<string>
            {
               "Программирование это интересно",
               "Купил продукты в магазине",
               "Люблю программировать"
            };

            foreach (var result in results)
            {
                Assert.IsTrue(expectedTexts.Contains(result.Text));
            }
        }
    }
}
