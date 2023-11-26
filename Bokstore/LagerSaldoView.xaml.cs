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
using System.Windows.Shapes;

namespace Bokstore
{
    /// <summary>
    /// Interaction logic for LagerSaldo.xaml
    /// </summary>
    public partial class LagerSaldoView : Window
    {
        private BookstoreDBContext _dbContext;
        public LagerSaldoView()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
            LoadLagerSaldo();
        }
        private void LoadLagerSaldo()
        {
            var LagerSaldo1 = _dbContext.LagerSaldos.ToList();
            DataGridLagerSaldo.ItemsSource = LagerSaldo1;
        }

        private void LäggtillSaldo_Click(object sender, RoutedEventArgs e)
        {
            LäggTillSaldo win1 = new LäggTillSaldo();
            win1.Show();
        }
    }
}

