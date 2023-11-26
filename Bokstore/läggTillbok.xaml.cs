using Bokstore.Data;
using Bokstore.Models;
using Microsoft.VisualBasic;
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
    /// Interaction logic for läggTillbok.xaml
    /// </summary>
    public partial class läggTillbok : Window
    {
        private BookstoreDBContext _dbContext;
        public läggTillbok()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
        }

        private void LäggtillBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Isbntb!= null)
            {
                Böcker nybok = new Böcker();
                nybok.Isbn = Isbntb.Text;
                nybok.Titel = Titletb.Text;
                nybok.Sprak = Språktb.Text;
                nybok.ForfattarId = int.Parse(FörattarIdtb.Text);
                nybok.Pris = decimal.Parse(Pristb.Text);
                nybok.Utgivningsdatum = DateTime.Parse(Utgivingsdatumtb.Text);
                _dbContext.Add(nybok);
                _dbContext.SaveChanges();
            }else
            {
                MessageBox.Show("Skriv in ett Isbn");
            }
        }
    }
}
