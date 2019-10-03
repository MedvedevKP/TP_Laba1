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

namespace App_for_TextData
{
    /// <summary>
    /// Логика взаимодействия для WindowAbout.xaml
    /// </summary>
    public partial class WindowAbout : Window
    {
        public WindowAbout()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Img_about_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            img_about.Source = new BitmapImage(new Uri("user2.jpg", UriKind.Relative));
        }
        
    }
}
