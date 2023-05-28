using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Coursework
{

    public partial class MainWindow : Window
    {
        static Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        // Початок разрахунку при натисненні на кнопку
        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            double xMin, xMax, dx;

            if (!checkTextBox(xMinBox, xMaxBox, dxBox))
                return;

            getVariables(out xMin, out xMax, out dx);

            if (!checkMinMax(xMin, xMax))
                return;

            showResults(xMin, xMax, dx);
        }

        // Виводить результат у вікно 
        private void showResults(double xMin, double xMax, double dx)
        {
            List<Function1> res1 = new List<Function1>();
            List<Function2> res2 = new List<Function2>();

            double a = random.NextDouble();

            for (double x = xMin; x <= xMax; x += dx)
            {
                double q = random.NextDouble();
                if (q <= 0.5)
                {
                    Function1 func1 = new Function1(x, q);          
                    res1.Add(func1);
                }
                else
                {
                    Function2 func2 = new Function2(x, a, q);
                    res2.Add(func2);                  
                }                      
            }

            Func1ResultGrid.ItemsSource = res1;
            Func2ResultGrid.ItemsSource = res2;

            func1CalcNumberLabel.Content = "Кількість обчислень: " + res1.Count().ToString();
            func2CalcNumberLabel.Content = "Кількість обчислень: " + res2.Count().ToString();
        }


        // Перевіряє ввід користувачем необхідних значень в TextBox
        private bool checkTextBox(params TextBox[] textBoxes)
        { 
            double x;
            foreach (TextBox textBox in textBoxes)
            {
                if (!double.TryParse(textBox.Text, out x))
                {
                    MessageBox.Show($"  Некоректно введені дані!\n  Повторіть спробу!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            return true;
        }
        
        // Перевіряє чи значення мінімум менше ніж максимуму
        private bool checkMinMax(double xMin, double xMax)
        {
            if (xMin > xMax)
            {
                MessageBox.Show("Xmin > Xmax!\n Перевірте значення!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        // Присвоює необхідні значення змінним
        private void getVariables(out double xMin, out double xMax, out double dx)
        {
            double.TryParse(xMinBox.Text, out xMin);
            double.TryParse(xMaxBox.Text, out xMax);
            double.TryParse(dxBox.Text, out dx);
        }
        
        // Функція що не дає користувачу вводити некоректні символи для обчислень
        private void filterDigits(TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch) && ch != 8 && ch != '-' && ch != ',')
                {
                    e.Handled = true;
                    break;
                }
            }           
        }

        private void xMinBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            filterDigits(e);
        }

        private void xMaxBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            filterDigits(e);
        }

        private void dxBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            filterDigits(e);
        }       
    }
}
