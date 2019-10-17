﻿using App_for_TextData;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Windows;

namespace TP_Laba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList AL;


        public MainWindow()
        {
            InitializeComponent();

        }

        private bool ArrayListGeneration()
        {

            try
            {
                uint countItem = Convert.ToUInt32(tBox_countElem.Text);

                AL = new ArrayList();
                Random rnd1 = new Random();
                int number;
                lbMain.Items.Clear();
                AL.Clear();
                for (int index = 1; index <= countItem; index++)
                {
                    number = -100 + rnd1.Next(200);
                    AL.Add(number);
                    lbMain.Items.Add(number);

                }

                if (lbMain.Items.Count != 0 && AL.Count != 0)
                    return true;
                else return false;
            }
            catch(Exception excep)
            {
                MessageBox.Show("Массив не был создан!\n"+excep.Message, "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                lbMain.Items.Clear();
               
               
                return false;
            }


        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_task1_Click(object sender, RoutedEventArgs e)
        {
         
                ArrayListGeneration();
    

        }

        private void Btn_task2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbMain.Items.Add("Неотсортированный массив:");
                if (ArrayListGeneration())
                {
                    AL.Sort();
                    lbMain.Items.Add("Отсортированный массив");
                    foreach (int elem in AL)
                    {
                        lbMain.Items.Add(elem);
                    }
                }
                else
                    AL.Clear();
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
         
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

            if (lbMain.Items.Count == 0)
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
                if (ArrayListGeneration())
                {
                    int count = 0;
                    for (int i = 1; i < AL.Count - 1; i++)
                    {
                        if (Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[i + 1]) && Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[i - 1]))
                            count++;
                    }

                    MessageBox.Show("Количество элементов массива больше своих «соседей»: " + count.ToString());
                }

            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_task4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
 
                int myIndex = 0;
                if (ArrayListGeneration())
                {

                    foreach (int elem in AL)
                    {

                        if (elem > 25)
                        {
                            MessageBox.Show("Первый элемент бельше 25 встречается на позиции:" + myIndex.ToString());
                            break;
                        }
                        myIndex++;

                    }
                }

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

                if (ArrayListGeneration())
                {

                    int summ = 0;

                    for (int i = 0; i < AL.Count; i++)
                    {
                        if (Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[1]))
                        {
                            summ += Convert.ToInt32(AL[i]);
                        }
                    }

                        MessageBox.Show("сумма элементов больших, чем " + AL[1].ToString() + " (второй элемент этого массива):" + summ.ToString());

                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            catch (OverflowException oe)
            {
                MessageBox.Show(oe.Message, "ой...", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        private void Btn_task6_Click(object sender, RoutedEventArgs e)
        {

            if (ArrayListGeneration()){

                myInputBox myIB = new myInputBox(0);
                if (myIB.ShowDialog().Value == true)
                {
                    int tmp = myIB.K;


                    for (int index = 0; index < AL.Count; index++)
                    {

                        if ((int)AL[index] > tmp)

                        {
                            MessageBox.Show("Первый элемент бельше " + tmp + " встречается на позиции:" + index.ToString());
                            break;
                        }

                    }
                }
            }
 
        }

        private void Btn_task7_Click(object sender, RoutedEventArgs e)
        {


            if (ArrayListGeneration()){

                myInputBox myIB = new myInputBox(0);
                if (myIB.ShowDialog().Value == true)
                {
                    int tmp = myIB.K;

                    if (tmp >= AL.Count || tmp < 0)
                    {
                        MessageBox.Show("Операция не выполнима, так как элемента с заданными индексом нет!", "Упсс...", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int summ = 0;

                    for (int i = 0; i < AL.Count; i++)
                    {
                        if (Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[tmp]))
                            summ += Convert.ToInt32(AL[i]);
                    }



                    MessageBox.Show("сумма элементов больших, чем " + AL[tmp].ToString() + "(встречается на позиции " + tmp.ToString() + "):" + summ.ToString());



                }
            }
         }


           

      

        private void Btn_task8_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ArrayListGeneration())
                {


                    for (int i = 1; i < AL.Count - 1; i++)
                    {
                        if (Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[i + 1]) && Convert.ToInt32(AL[i]) > Convert.ToInt32(AL[i - 1]))
                        {

                            lbMain.SelectedItems.Add(AL[i]);

                        }

                    }

                    MessageBox.Show("Количество элементов массива больше своих «соседей»: " + lbMain.SelectedItems.Count.ToString());
                }

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

        private void Btn_CgeateChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chart wndChart = new chart(AL);
                wndChart.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}