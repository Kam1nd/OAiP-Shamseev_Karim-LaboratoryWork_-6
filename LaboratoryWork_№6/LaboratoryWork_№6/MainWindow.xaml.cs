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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaboratoryWork__6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            var task1Window = new Task1Window();
            task1Window.Show();
            this.Hide();
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            var task2Window = new Task2Window();
            task2Window.Show();
            this.Hide();
        }
        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            var task3Window = new Task3Window();
            task3Window.Show();
            this.Hide();
        }

        private void Task4_Click(object sender, RoutedEventArgs e)
        {
            var task4Window = new Task4Window();
            task4Window.Show();
            this.Hide();
        }

        private void Task5_Click(object sender, RoutedEventArgs e)
        {
            var task5Window = new Task5Window();
            task5Window.Show();
            this.Hide();
        }

        private void Task6_Click(object sender, RoutedEventArgs e)
        {
            var task6Window = new Task6Window();
            task6Window.Show();
            this.Hide();
        }
    }
}
