﻿
using GeniyIdiotCommon;
using System;
using System.Windows.Forms;
namespace GeniiIdiotWinFormsApp1
{
    public partial class GeniiIdiotWinFormsApp : Form
    {
        private User user;
        private Game game;
        int numberOfQuestions = 0; 

        public GeniiIdiotWinFormsApp()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var userInfoForm = new UserInfoForm();
            userInfoForm.okButton.Enabled = false;
            if (String.IsNullOrWhiteSpace(userInfoForm.userSurnameTextBox.Text) ||
                    String.IsNullOrWhiteSpace(userInfoForm.userNameTextBox.Text))
            {
                userInfoForm.okButton.Enabled = true;
            }

                if (userInfoForm.ShowDialog(this) == DialogResult.OK)
                {
                    var userSurname = userInfoForm.userSurnameTextBox.Text;
                    var userName = userInfoForm.userNameTextBox.Text;
                    user = new User(userName, userSurname);
                    game = new Game(user);
                    numberOfQuestions = game.GetNumberOfQuestions();
                    PrintNextQuestion();
                }
                else Close();
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            int userAnswer;
            if (!int.TryParse(userAnswerTextBox.Text, out userAnswer))
            {
                MessageBox.Show("Введите число!");
                userAnswerTextBox.Clear();
                userAnswerTextBox.Focus();
            }
            else
            {
                game.AcceptUserAnswer(userAnswer);
                PrintNextQuestion();
            }
        }



        private void PrintNextQuestion()
        {
            if (game.IsEnd())
            {
                game.CalculateDiagnose(numberOfQuestions);
                game.SaveResult(game.userResults);
                MessageBox.Show(user.Diagnose);
            }
            else
            {
                userAnswerTextBox.Focus();
                questionTextLabel.Text = game.PopRandomeQuestion().Text;
                questionNumberLabel.Text = game.GetCurrentQuestionNumberInfo();
                userAnswerTextBox.Clear();
            }
        }

        private void ShowPreviousResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userResults = game.GetUserResults();
            var userResultsForm = new UserResultsForm(userResults);
            userResultsForm.Show();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddNewQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addQuestionForm = new AddQuestionForm(game);
            addQuestionForm.Show();
        }

        private void DeleteQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
