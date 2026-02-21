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
    public partial class Task3Window : Window
    {
        public Task3Window()
        {
            InitializeComponent();
        }

        private void CheckLocalMin(object sender, RoutedEventArgs e)
        {
            string input = InputText.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите числа!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string[] parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                MessageBox.Show("Введите хотя бы одно число!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(parts[0], out int count))
            {
                MessageBox.Show("Первое число должно быть количеством", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (count <= 0 && count > 1000)
            {
                MessageBox.Show("Количество должно быть больше 0 и меньше 1000", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int expectedLength = count + 1;
            if (parts.Length != expectedLength)
            {
                MessageBox.Show($"Ожидается {expectedLength} чисел (1 счётчик + {count} элементов), введено: {parts.Length}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int[] array = new int[count];

            for (int i = 0; i < count; i++)
            {
                if (!int.TryParse(parts[i + 1], out int value))
                {
                    MessageBox.Show($"Некорректное значение на позиции {i + 1}: \"{parts[i + 1]}\"", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                array[i] = value;
            }

            if (count < 3)
            {
                MessageBox.Show("Нужно минимум 3 элемента для поиска", "Ошибка",
    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int localMinCount = 0;
            for (int i = 1; i < count - 1; i++)
            {
                if (array[i] < array[i - 1] && array[i] < array[i + 1])
                {
                    localMinCount++;
                }
            }

            ResultTextBlock.Text = $" Локальных минимумов: {localMinCount}";
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task3toTask2(object sender, RoutedEventArgs e)
        {
            var task2Window = new Task2Window();
            task2Window.Show();
            this.Close();
        }

        private void Task3toTask4(object sender, RoutedEventArgs e)
        {
            var task4Window = new Task1Window();
            task4Window.Show();
            this.Close();
        }
    }
}
