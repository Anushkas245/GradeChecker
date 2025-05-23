using System;
using System.Drawing;
using System.Windows.Forms;

namespace GradeChecker
{
    public partial class Form1 : Form
    {
        Label lblEnterMarks;
        TextBox txtMarks;
        Button btnCheckGrade;
        Label lblResult;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Grade Checker";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Label for Enter Marks
            lblEnterMarks = new Label()
            {
                Text = "Enter Markss:",
                Location = new Point(40, 40),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblEnterMarks);

            // TextBox for Marks
            txtMarks = new TextBox()
            {
                Location = new Point(200, 35),
                Width = 120,
                Font = new Font("Segoe UI", 12)
            };
            this.Controls.Add(txtMarks);

            // Button for Check Grade
            btnCheckGrade = new Button()
            {
                Text = "Check Grade",
                Location = new Point(130, 90),
                Width = 120,
                Height = 40,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnCheckGrade.FlatAppearance.BorderSize = 0;
            btnCheckGrade.Click += BtnCheckGrade_Click;
            this.Controls.Add(btnCheckGrade);

            // Label for Result
            lblResult = new Label()
            {
                Text = "",
                Location = new Point(40, 160),
                Width = 300,
                Height = 40,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            this.Controls.Add(lblResult);
        }

        private void BtnCheckGrade_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMarks.Text, out int marks))
            {
                if (marks >= 0 && marks <= 100)
                {
                    string grade = GetGrade(marks);
                    lblResult.Text = $"Grade: {grade}";
                }
                else
                {
                    MessageBox.Show("Please enter a number between 0 and 100.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter numeric marks.");
            }
        }

        private string GetGrade(int marks)
        {
            if (marks >= 90) return "A+";
            else if (marks >= 80) return "A";
            else if (marks >= 70) return "B";
            else if (marks >= 60) return "C";
            else if (marks >= 50) return "D";
            else return "F";
        }
    }
}
