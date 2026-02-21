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

    public partial class Task4Window : Window
    {
        public Task4Window()
        {
            InitializeComponent();
        }

        private void CreateMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SizeTextBox.Text, out int size))
            {
                MessageBox.Show("Введите корректный размер матрицы!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (size < 2 && size > 10)
            {
                MessageBox.Show("Размер должен быть минимум 2×2 и максимум 10×10!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ResultTextBlock.Text = "";
        }

        private void CheckSymmetry_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SizeTextBox.Text, out int size))
            {
                MessageBox.Show("Введите размер матрицы!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string input = InputTextBox.Text.Trim();
            string[] parts = input.Split(new[] { ' ', '\n', '\r', '\t' },
                                         StringSplitOptions.RemoveEmptyEntries);

            int expectedCount = size * size;
            if (parts.Length != expectedCount)
            {
                MessageBox.Show($"Ожидается {expectedCount} элементов ({size}×{size}), введено: {parts.Length}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double[,] matrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = i * size + j;

                    if (!double.TryParse(parts[index], out double value))
                    {
                        MessageBox.Show($"Некорректное значение на позиции ({i},{j}): \"{parts[index]}\"", "Ошибка",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    matrix[i, j] = value;
                }
            }

            bool isSymmetric = true;

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)  
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        isSymmetric = false;
                    }
                }
            }

            if (isSymmetric)
            {
                ResultTextBlock.Text = "Матрица СИММЕТРИЧНА!";
            }
            else
            {
                ResultTextBlock.Text = "Матрица НЕ симметрична!";
            }
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task4toTask3(object sender, RoutedEventArgs e)
        {
            var task3Window = new Task3Window();
            task3Window.Show();
            this.Close();
        }

        private void Task4toTask5(object sender, RoutedEventArgs e)
        {
            var task5Window = new Task5Window();
            task5Window.Show();
            this.Close();
        }
    }
}
