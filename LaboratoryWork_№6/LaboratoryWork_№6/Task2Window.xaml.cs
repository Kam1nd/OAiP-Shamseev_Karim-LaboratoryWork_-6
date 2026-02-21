using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaboratoryWork__6
{
    public partial class Task2Window : Window, INotifyPropertyChanged
    {
        private string _question;
        private int _currentQuestionIndex = 0;
        private int _correctAnswers = 0;
        private int _totalQuestions = 10;

        private readonly string[] _questions = {
            "5 × 2 = ", "5 × 3 = ", "5 × 4 = ", "5 × 5 = ", "5 × 6 = ",
            "5 × 7 = ", "5 × 8 = ", "5 × 9 = ", "5 × 10 = ", "6 × 7 = "
        };

        private readonly int[] _answers = {
            10, 15, 20, 25, 30, 35, 40, 45, 50, 42
        };

        public string Question
        {
            get => _question;
            set { _question = value; OnPropertyChanged(nameof(Question)); }
        }

        public Task2Window()
        {
            InitializeComponent();
            DataContext = this;
            StartTest();
        }

        private void StartTest()
        {
            _currentQuestionIndex = 0;
            _correctAnswers = 0;
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_currentQuestionIndex < _totalQuestions)
            {
                Question = _questions[_currentQuestionIndex];
            }
            else
            {
                ShowFinalResult();
            }
        }

        private void CheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputText.Text, out int userAnswer))
            {
                if (userAnswer == _answers[_currentQuestionIndex])
                {
                    _correctAnswers++;
                }

                _currentQuestionIndex++;
                InputText.Text = "";
                LoadQuestion();
            }
            else
            {
                MessageBox.Show("Введите число!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowFinalResult()
        {
            string grade;

            if (_correctAnswers == 10)
                grade = "отлично";
            else if (_correctAnswers >= 8)
                grade = "хорошо";
            else if (_correctAnswers >= 6)
                grade = "удовлетворительно";
            else
                grade = "неудовлетворительно";

            ResultTextBlock.Text = $"Тест завершён!\nПравильных ответов: {_correctAnswers} из {_totalQuestions}\nОценка: {grade}";

            InputText.IsEnabled = false;
            CheckButton.IsEnabled = false;
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task2toTask3(object sender, RoutedEventArgs e)
        {
            var task3Window = new Task3Window(); 
            task3Window.Show();
            this.Close();
        }

        private void Task2toTask1(object sender, RoutedEventArgs e)
        {
            var task1Window = new Task1Window(); 
            task1Window.Show();
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
