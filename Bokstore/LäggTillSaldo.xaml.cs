using Bokstore.Data;
using Bokstore.Models;
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
    /// Interaction logic for LäggTillSaldo.xaml
    /// </summary>
    public partial class LäggTillSaldo : Window
    {
        private BookstoreDBContext _dbContext;
        public LäggTillSaldo()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();

        }

        private void LäggtillSaldobtn_Click(object sender, RoutedEventArgs e)
        {
            LagerSaldo NySaldo = new LagerSaldo();
            NySaldo.ButikId = System.Convert.ToInt32(ButikIdtb.Text);
            NySaldo.Isbn = Isbntb.Text;
            NySaldo.Antal = System.Convert.ToInt32(Antaltb.Text);
            _dbContext.Add(NySaldo);
            _dbContext.SaveChanges();
            Close();

        }
    }
}
