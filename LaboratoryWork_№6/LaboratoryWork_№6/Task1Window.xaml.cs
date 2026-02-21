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
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task1toTask2(object sender, RoutedEventArgs e)
        {
            var task2Window = new Task2Window();
            task2Window.Show();
            this.Close();
        }

        private void Calculation(object sender, RoutedEventArgs e)
        {
            string input = InputText.Text;

            if (double.TryParse(input, out double a)) 
            {
                double result;

                if (a <= 2)
                    result = a * a + 4 * a + 5;
                else
                {
                    double denominator = a * a + 4 * a + 5;

                    while (true) {
                        if (denominator != 0) 
                        { 
                            result = 1.0 / denominator;
                            ResultTextBlock.Text = $"f({a}) = {result:F4}";
                            break;
                        }
                        else
                        {
                            ResultTextBlock.Text = "Не определено";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите корректное число", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
