﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class NameForm : Form
    {
        public UserScore userScore;
        public NameForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var userName = nameTextBox.Text;
            var userScore = new UserScore(userName);
            Close();
        }
    }
}