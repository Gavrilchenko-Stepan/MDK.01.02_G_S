using Commantary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyForm
{
    public partial class Form1: Form
    {
        private CommentaryManager manager;

        public Form1()
        {
            InitializeComponent();

            ICommentaryRepository repo = new CommentaryRepo();
            manager = new CommentaryManager(repo);

            comboBoxUsers.Items.Add("Ирина");
            comboBoxUsers.Items.Add("Влад");
            comboBoxUsers.Items.Add("Петр");

            if (comboBoxUsers.Items.Count > 0)
                comboBoxUsers.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }

            string login = comboBoxUsers.SelectedItem.ToString();
            string comment = commentText.Text.Trim();

            if (string.IsNullOrWhiteSpace(comment))
            {
                MessageBox.Show("Введите комментарий!");
                return;
            }

            manager.AddComment(login, comment);
            commentText.Clear();
            MessageBox.Show("Комментарий добавлен!");

            RefreshComments();
        }

        private void RefreshComments()
        {
            if (comboBoxUsers.SelectedItem == null) return;

            string login = comboBoxUsers.SelectedItem.ToString();
            var comments = manager.GetUserComments(login);

            CommentsText.Clear();

            if (comments.Count > 0)
            {
                foreach (string comment in comments)
                {
                    CommentsText.AppendText($"• {comment}\n");
                }
            }
            else
            {
                CommentsText.Text = "Комментарии отсутствуют";
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshComments();
        }
    }
}
