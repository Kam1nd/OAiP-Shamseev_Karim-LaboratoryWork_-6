
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaboratoryWork__6
{
    public partial class Task5Window : Window
    {
        private int[,] _originalMatrix;
        private int[,] _rotatedMatrix;
        private int _rows;
        private int _cols;

        public Task5Window()
        {
            InitializeComponent();
        }

        private void GenerateRandom_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RowsTextBox.Text, out _rows) ||
                !int.TryParse(ColsTextBox.Text, out _cols))
            {
                MessageBox.Show("Введите размеры матрицы!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_rows < 1 || _rows > 20 || _cols < 1 || _cols > 20)
            {
                MessageBox.Show("Размеры должны быть от 1 до 20!", "Ошибка",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _originalMatrix = new int[_rows, _cols];
            Random rand = new Random();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _originalMatrix[i, j] = rand.Next(-20, 21);
                }
            }

            DrawMatrix(OriginalMatrixGrid, _originalMatrix, _rows, _cols);

            RotateMatrix();

            DrawMatrix(RotatedMatrixGrid, _rotatedMatrix, _cols, _rows);

        }

        private void RotateMatrix()
        {
            _rotatedMatrix = new int[_cols, _rows];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _rotatedMatrix[j, _rows - 1 - i] = _originalMatrix[i, j];
                }
            }
        }

        private void DrawMatrix(Grid grid, int[,] matrix, int rows, int cols)
        {
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });
            }

            for (int j = 0; j < cols; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Text = matrix[i, j].ToString(),
                        FontSize = 14,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Padding = new Thickness(5)
                    };
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, j);
                    grid.Children.Add(textBlock);
                }
            }
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Task5toTask4(object sender, RoutedEventArgs e)
        {
            var task4Window = new Task4Window();
            task4Window.Show();
            this.Close();
        }

        private void Task5toTask6(object sender, RoutedEventArgs e)
        {
            var task6Window = new Task6Window();
            task6Window.Show();
            this.Close();
        }
    }
}