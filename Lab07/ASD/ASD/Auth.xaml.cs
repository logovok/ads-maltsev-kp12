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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (Globals.citte.login(TB1_Copy.Text, TB2.Text, TB3.Password))
            {
                Finnl fnnn = new Finnl(TB1_Copy.Text, TB2.Text, TB3.Password);
                this.Hide();
                fnnn.Show();
            }
            else
            {
                MessageBox.Show("incorrect");
            }
        }
        private void oncl(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }        
    }
}
