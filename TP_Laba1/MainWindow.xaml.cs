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
using System.Collections;
using System.IO;
using Microsoft.Win32;
using App_for_TextData;

namespace TP_Laba1
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

        private uint get_coutNumbers()
        {
            try {
                return Convert.ToUInt32(tBox_countElem.Text);
            }
            catch(FormatException fe)
            {
                MessageBox.Show(fe.Message, "Упс...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(OverflowException oe)
            {
                MessageBox.Show(oe.Message, "Упс...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return 0;
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_task1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;


                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);
                }
            }
            catch
            {
                MessageBox.Show("Необработанная ошибка");
            }
         
        }

        private void Btn_task2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();
                lbMain.Items.Add("Исходный массив");
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);
                }
                myAL.Sort();
                lbMain.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    lbMain.Items.Add(elem);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //}
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

            if(lbMain.Items.Count == 0)
            {
                MessageBox.Show("Список пустой!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void Btn_task3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();
             
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);
                }

                int count = 0;
                for(int i=1; i < myAL.Count - 1; i++)
                {
                    if (Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[i + 1]) && Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[i - 1]))
                        count++;
                }

                MessageBox.Show("Количество элементов массива больше своих «соседей»: " + count.ToString());

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_task4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                int myIndex = -1;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();

                for (index = 0; index < itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);

                    if (number > 25 && myIndex == -1)
                        myIndex = index;

                }

               

                MessageBox.Show("Первый элемент бельше 25 встречается на позиции:" + myIndex.ToString());

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_task5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();

                for (index = 0; index < itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);

                }

                int summ = 0;

                for(int i=0; i < myAL.Count; i++)
                {
                    if(Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[1]))
                    {
                        summ += Convert.ToInt32(myAL[i]);
                    }
                }

                if(itemCount > 0)
                MessageBox.Show("сумма элементов больших, чем "+myAL[1].ToString()+" (второй элемент этого массива):" + summ.ToString());

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            catch(OverflowException oe)
            {
                MessageBox.Show(oe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        private void Btn_task6_Click(object sender, RoutedEventArgs e)
        {
         

            myInputBox myIB = new myInputBox(0);
           if( myIB.ShowDialog().Value==true)
            {
                int tmp = myIB.K;

                try
                {
                    ArrayList myAL = new ArrayList();
                    int index;
                    int myIndex = -1;
                    uint itemCount = get_coutNumbers();
                    if (itemCount == 0)
                        return;
                    Random rnd1 = new Random();
                    int number;
                    lbMain.Items.Clear();

                    for (index = 0; index < itemCount; index++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        lbMain.Items.Add(number);

                        if (number > tmp && myIndex == -1)
                            myIndex = index;

                    }



                    MessageBox.Show("Первый элемент бельше "+tmp+" встречается на позиции:" + myIndex.ToString());

                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.ToString(), "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void Btn_task7_Click(object sender, RoutedEventArgs e)
        {


            myInputBox myIB = new myInputBox(0);
            if (myIB.ShowDialog().Value == true)
            {
                int tmp = myIB.K;

                try
                {
                    ArrayList myAL = new ArrayList();
                    int index;
                    int summ = 0;
                    uint itemCount = get_coutNumbers();
                    if (itemCount == 0)
                        return;
                    if (tmp >= itemCount || tmp < 0)
                    {
                        MessageBox.Show("Операция не выполнима, так как элемента с заданными индексом нет!", "Упсс...", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Random rnd1 = new Random();
                    int number;
                    lbMain.Items.Clear();

                    for (index = 0; index < itemCount; index++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        lbMain.Items.Add(number);

                    }

                    for (int i=0; i < myAL.Count; i++)
                    {
                        if (Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[tmp]))
                            summ += Convert.ToInt32(myAL[i]);
                    }



                    MessageBox.Show("сумма элементов больших, чем " + myAL[tmp].ToString() + "(встречается на позиции "+tmp.ToString()+ "):" + summ.ToString());

                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void Btn_task8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayList myAL = new ArrayList();
                int index;
                uint itemCount = get_coutNumbers();
                if (itemCount == 0)
                    return;
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();

                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    lbMain.Items.Add(number);
                }

            
                for (int i=1; i < myAL.Count-1; i++)
                {
                    if (Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[i + 1]) && Convert.ToInt32(myAL[i]) > Convert.ToInt32(myAL[i - 1]))
                    {
                       
                        lbMain.SelectedItems.Add(myAL[i]);
                       
                    }

                }

                MessageBox.Show("Количество элементов массива больше своих «соседей»: " + lbMain.SelectedItems.Count.ToString());

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_about_Click(object sender, RoutedEventArgs e)
        {
            WindowAbout wa = new WindowAbout();
            wa.ShowDialog();

            
        }
    }
}
