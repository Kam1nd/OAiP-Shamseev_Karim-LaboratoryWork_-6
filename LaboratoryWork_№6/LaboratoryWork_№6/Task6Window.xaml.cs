using System;
using System.Collections.Generic;
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
    public partial class Task6Window : Window
    {
        public Task6Window()
        {
            InitializeComponent();
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task6toTask5(object sender, RoutedEventArgs e)
        {
            var task5Window = new Task5Window();
            task5Window.Show();
            this.Close();
        }

        private void CalcSumm(object sender, RoutedEventArgs e)
        {
            Salary salary = new Salary();
            string inputTextWage = InputTextWage.Text;
            string inputTextDays = InputTextDays.Text;
            string inputTextMonth = InputTextMonth.Text;
            if (double.TryParse(inputTextWage, out double wage))
            salary.Wage = wage;
            else
                MessageBox.Show("Введите корректный оклад!", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Warning);

            if ((int.TryParse(inputTextDays, out int days)))
            {
                if (days >= 32)
                {
                    MessageBox.Show("Введите корректные дни! (не больше 31)", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                salary.Days = days;
            }
            else
                MessageBox.Show("Введите корректные дни!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);

            if ((int.TryParse(inputTextMonth, out int month)))
            {
                if (month >=13)
                {
                    MessageBox.Show("Введите корректный номер месяца! (не больше 12)", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                salary.Month = month;
            }
            else
                MessageBox.Show("Введите корректный номер месяца!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);

            ResultTextBlock.Text = $"Ваша зарплата {salary.summa()}";
        }
    }
}
