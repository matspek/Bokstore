using Bokstore.Data;
using Bokstore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
    /// Interaction logic for Bokerwin.xaml
    /// </summary>
    public partial class Bokerwin : Window
    {
        private BookstoreDBContext _dbContext;
        Böcker CurrentBook;
        public Bokerwin()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
            LoadBocker();
        }
        private void LoadBocker()
        {
            var Bocker1 = _dbContext.Böckers.ToList();
            DatagridBocker.ItemsSource = Bocker1;
        }

        private void DatagridBocker_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentBook = DatagridBocker.CurrentCell.Item as Böcker; 
            BokName.Text = CurrentBook.Titel;
            Språk.Text = CurrentBook.Sprak;
            Pris.Text = System.Convert.ToString(CurrentBook.Pris);
            ForfattarId.Text = System.Convert.ToString(CurrentBook.Forfattar);

        }

        private void SaveBookBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentBook.Titel = BokName.Text;
            CurrentBook.Sprak = Språk.Text;
            CurrentBook.Pris = Convert.ToDecimal(Pris.Text);
            CurrentBook.ForfattarId = System.Int32.Parse(ForfattarId.Text);
            _dbContext.SaveChanges();
            LoadBocker();
        }

        private void TabortBokBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentBook = DatagridBocker.SelectedItem as Böcker;

            _dbContext.LagerSaldos.Remove(_dbContext.LagerSaldos.FirstOrDefault(test => test.Isbn == CurrentBook.Isbn));
            
            _dbContext.Böckers.Remove(CurrentBook);        
            _dbContext.SaveChanges();
            LoadBocker();
        }

        private void Läggtillbokbtn_Click(object sender, RoutedEventArgs e)
        {
            läggTillbok win4 = new läggTillbok();
            win4.Show();

        }
    }
}
