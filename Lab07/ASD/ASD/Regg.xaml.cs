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
    /// Логика взаимодействия для Regg.xaml
    /// </summary>
    partial class Regg : Window
    {
        
         public Regg()
        {
            InitializeComponent();
        }
        private void oncl(object sender, EventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB4.Text.Split('@').Length != 2)
            {
                MessageBox.Show("Incorrect e-mail format");
                return;

            }
            try
            {
                Globals.citte.reg(TB5.Text, TB2.Text, TB3.Password, TB4.Text);
                //  MessageBox.Show(TB5.Text + TB2.Text+ TB3.Password+ TB4.Text);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Hide();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
                MessageBox.Show(exc.StackTrace);
            }
            
        }
    }
}
