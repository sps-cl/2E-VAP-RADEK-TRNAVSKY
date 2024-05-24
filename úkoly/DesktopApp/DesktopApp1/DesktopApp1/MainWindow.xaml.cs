using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
        }

        private void Červená (object sender, RoutedEventArgs e)
        {
            rectangle.Fill = new SolidColorBrush(Colors.Red);
        }

        private void Zelená (object sender, RoutedEventArgs e)
        {
            rectangle.Fill = new SolidColorBrush(Colors.Green);
        }

        private void Modrá (object sender, RoutedEventArgs e)
        {
           rectangle.Fill= new SolidColorBrush(Colors.Blue);
        }
    }
}