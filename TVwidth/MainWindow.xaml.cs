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

namespace TVwidth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string HEIGHT = "Высота: {0:0.00}см";
        const string WIDTH = "Ширина: {0:0.00}см";
        const string ERROR_INPUT = "Не подходящее значение в поле ввода.";
        readonly int[] heights = new int[] { 3, 9, 10 };
        readonly int[] widths = new int[] { 4, 16, 16 };

        public MainWindow()
        {
            InitializeComponent();
            Icon = Properties.Resources.main.ToBitmap().ToImageSource();
            tvImage.Source = Properties.Resources.tv_size.ToImageSource();
            var ratio = new List<string>();
            for (int i = 0; i < heights.Length; i++)
            {
                ratio.Add(string.Format("{0}:{1}", widths[i], heights[i]));
            }
            ratioComboBox.ItemsSource = ratio;
            clearLabels();
        }

        private void diagonalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearLabels();
            setSize(diagonalTextBox.Text);
        }

        private void clearLabels()
        {
            heightLabel.Content = string.Empty;
            widthLabel.Content = string.Empty;
            messageLabel.Content = string.Empty;
        }

        private void setLabels(Size size)
        {
            heightLabel.Content = string.Format(HEIGHT, size.Height);
            widthLabel.Content = string.Format(WIDTH, size.Width);
        }

        private void setSize(string diagonal)
        {
            int c;
            if (!int.TryParse(diagonal, out c))
            {
                messageLabel.Content = ERROR_INPUT;
                return;
            }
            var i = ratioComboBox.SelectedIndex;
            setLabels(Calculator.Execute(c, widths[i], heights[i]));
        }
    }
}
