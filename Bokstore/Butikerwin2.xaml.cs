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
    /// Interaction logic for Butikerwin2.xaml
    /// </summary>
    public partial class Butikerwin2 : Window
    {
        private BookstoreDBContext _dbContext;
        
        public Butikerwin2()
        {
            InitializeComponent();
            _dbContext = new BookstoreDBContext();
            LoadButiker();

        }
        private void LoadButiker()
        {
            var Butiker1 = _dbContext.Butikers.ToList();
            DatagridButiker2.ItemsSource = Butiker1;
        }
    }
}
