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
        private readonly IUserService _userService;

        public CommentService(ICommentRepository commentRepository, IUserService userService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
        }

        public Comment AddComment(int userId, string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не может быть пустым");

            if (!_userService.UserExists(userId))
                throw new ArgumentException("Пользователь не найден");

            var user = _userService.GetUser(userId);
            var comment = new Comment
            {
                Text = text,
                UserId = userId,
                User = user
            };

            _commentRepository.AddComment(comment);
            return comment;
        }

        public List<Comment> GetUserComments(int userId)
        {
            return _commentRepository.GetUserComments(userId);
        }
    }
}
