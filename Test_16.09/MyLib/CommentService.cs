using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment AddComment(int userId, string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не может быть пустым");

            var comment = new Comment
            {
                Text = text,
                UserId = userId,
            };

            _commentRepository.AddComment(comment);
            return comment;
        }

        public List<Comment> GetUserComments(int userId)
        {
            return _commentRepository.GetUserComments(userId);
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAllComments();
        }

        public List<Comment> SearchComments(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new List<Comment>();

            var allComments = GetAllComments();

            return allComments.Where(comment => comment.Text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
