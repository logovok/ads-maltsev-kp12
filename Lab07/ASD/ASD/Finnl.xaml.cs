using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ASD
{
    /// <summary>
    /// Логика взаимодействия для Finnl.xaml
    /// </summary>
    public partial class Finnl : Window
    {
        public Finnl(string n1, string n2, string pass)
        {
            t1 = n1; t2 = n2; p = pass;
            InitializeComponent();
            converted1 = new List<string>();
            converted2 = new List<string>();
            foreach (KyVal item in Globals.citte.getFriends(n1, n2))
            {
                if (item!=null)
                {

                    converted1.Add(item.FirstName + " " + item.LastName);
                }
            }
            foreach (KyVal item in Globals.citte.getFolks())
            {
                if (item!=null)
                {
                    if (item.FirstName!=null)
                    {
                        converted2.Add(item.FirstName + " " + item.LastName);
                    }
                    
                }
            }
            LBX.ItemsSource = converted1;
            CBX.ItemsSource = converted2;
        }
        string t1, t2, p;
        List<string> converted1, converted2;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbi = MessageBox.Show("Are you ready for self destruction?", "Just, you know, making it clear", MessageBoxButton.YesNo);
            if (mbi == MessageBoxResult.Yes)
            {
                Globals.citte.dellA(p);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Hide();
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (LBX.SelectedIndex == -1)
            {
                MessageBox.Show("If you wanna get rid of a friend, you must select one");
                return;

            }
            Globals.citte.frM(new KyVal(t1, t2), new KyVal(LBX.SelectedValue.ToString().Split(' ')[0], LBX.SelectedValue.ToString().Split(' ')[1]));
            mopsiyatina();
        }

        void mopsiyatina() {
            converted1 = new List<string>();
            converted2 = new List<string>();
            foreach (KyVal item in Globals.citte.getFriends(t1, t2))
            {
                if (item != null)
                {

                    converted1.Add(item.FirstName + " " + item.LastName);
                }
            }
            foreach (KyVal item in Globals.citte.getFolks())
            {
                if (item != null)
                {
                    if (item.FirstName != null)
                    {
                        converted2.Add(item.FirstName + " " + item.LastName);
                    }

                }
            }
            LBX.ItemsSource = converted1;
            CBX.ItemsSource = converted2;
        }

        bool checkeff(string s) {
            for (int i = 0; i < LBX.Items.Count; i++)
            {
                if (LBX.Items[i].ToString().Equals(s))
                {
                    return false;
                }
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBX.SelectedIndex == -1)
            {
                MessageBox.Show("You MUST select user. You just have to");
                return;

            }
            if (CBX.SelectedValue.ToString().Equals(t1+" "+t2))
            {
                MessageBox.Show("You can`t make friend with yourself");
                return;
            }
            if (!checkeff(CBX.SelectedItem.ToString()))
            {
                MessageBox.Show("Adding the same friend second time is not the thing you are supposed to do");
                return;
            }
            Globals.citte.frP(new KyVal(t1, t2), new KyVal(CBX.SelectedValue.ToString().Split(' ')[0], CBX.SelectedValue.ToString().Split(' ')[1]));
            mopsiyatina();
        }

        private void oncl(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
