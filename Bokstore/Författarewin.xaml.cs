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
    /// Interaction logic for Författarewin.xaml
    /// </summary>
    public partial class Författarewin : Window
    {
        private BookstoreDBContext _dbContext;
        public Forfattare CurrentForattare = new Forfattare();
        public Böcker CurrentBook = new Böcker();
        public Författarewin()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
            LoadForfattare();
        }
        private void LoadForfattare()
        {
            var Forfattare1 = _dbContext.Forfattares.ToList();
            DatagridForfattare.ItemsSource = Forfattare1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LäggtillföfattareWin win1 = new LäggtillföfattareWin();
            win1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentForattare = DatagridForfattare.SelectedItem as Forfattare;


            _dbContext.Böckers.Remove(_dbContext.Böckers.FirstOrDefault(test => test.ForfattarId == CurrentForattare.ForfattareId));
        //    _dbContext.LagerSaldos.Remove(_dbContext.LagerSaldos.FirstOrDefault(test => test.Isbn == CurrentForattare.Böckers.First<<Böcker>);
            _dbContext.Forfattares.Remove(CurrentForattare);
            _dbContext.SaveChanges();
            LoadForfattare();

        }
    }
}
