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

namespace SalesOrders
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string s1, string s2, string s3)
        {
            InitializeComponent();
            this.Title = s1;
            txtblk1.Text = "Total Sale Price of this order is $" + s2;
            txtblk2.Text = s3;

        }
    }
}
