using Bokstore.Data;
using Microsoft.EntityFrameworkCore;
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

namespace Bokstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookstoreDBContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
   //         _dbContext = new BookstoreDBContext();
   //         var Butiker1 = _dbContext.Butikers.ToList();
   //         MessageBox.Show(Butiker1.ToString());
        }

        private void Bokerbtn_Click(object sender, RoutedEventArgs e)
        {
            Bokerwin win2 = new Bokerwin();
            win2.Show();
        }

        private void Butikerbtn_Click(object sender, RoutedEventArgs e)
        {
            Butikerwin2 win3 = new Butikerwin2();
            win3.Show();
        }

        private void LagerSaldobtn_Click(object sender, RoutedEventArgs e)
        {
            LagerSaldoView win4 = new LagerSaldoView();
            win4.Show();
        }

        private void Författarebtn_Click(object sender, RoutedEventArgs e)
        {
            Författarewin win5 = new Författarewin();
             win5.Show();
        }
    }
}
