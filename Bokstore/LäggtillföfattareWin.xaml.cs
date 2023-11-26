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
    /// Interaction logic for LäggtillföfattareWin.xaml
    /// </summary>
    public partial class LäggtillföfattareWin : Window
    {
        private BookstoreDBContext _dbContext;
        public LäggtillföfattareWin()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
 
        }

        private void LäggtillFörfattareBtn_Click(object sender, RoutedEventArgs e)
        {
            Forfattare NyForfattare = new Forfattare();
            NyForfattare.Fornamn = Förnamntb.Text;
            NyForfattare.Efternamn = EfterNamntb.Text;
            NyForfattare.Fodelsedatum = DateTime.Parse(FödelseDatumtb.Text);
            Böcker Bok = new Böcker();
            Bok.Isbn = Böckertb.Text;
            NyForfattare.Böckers.Add((Bok));
            _dbContext.Add(NyForfattare);
            _dbContext.SaveChanges();
            Close();
        }

        private void Böckercb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void LäggtillFöttareBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Forfattare NyForfattare = new Forfattare();
        //    NyForfattare.Fornamn = Förnamntb.Text;
        //    NyForfattare.Efternamn = EfterNamntb.Text;
        //    NyForfattare.Fodelsedatum= DateTime.Parse(FödelseDatumtb.Text);
        //    NyForfattare.Böckers = Böckercb.SelectedItem;
        //    _dbContext.Add(NyForfattare);
        //    _dbContext.SaveChanges();
        //}
    }
}
