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

namespace ASD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class Globals {
        public static ConTainer citte = new ConTainer();
    }
    partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Regg rg = new Regg();
            rg.Show();
            this.Hide();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Auth au = new Auth();
            au.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Globals.citte.generateVelues();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Globals.citte.observeTables();
        }
    }
}
