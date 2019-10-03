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

namespace TP_Laba1
{
    /// <summary>
    /// Логика взаимодействия для myInputBox.xaml
    /// </summary>
    public partial class myInputBox : Window
    {

       public  int K { get
           ;
            private set; }
       public  bool status = false;
        
        public myInputBox(int k)
        {
            InitializeComponent();
          
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
           
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                K = Convert.ToInt32(tbInputNumber.Text);
                MainWindow log = Application.Current.Windows[0] as MainWindow;

                DialogResult = true;
               
               
            }
            catch(FormatException fe)
            {
                MessageBox.Show(fe.Message, "Упс...", MessageBoxButton.OK, MessageBoxImage.Warning);
               
            }
           
        }

  

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
