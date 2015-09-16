using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.IO;

namespace SalesOrders
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //Choice of order year
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            int[] years = { 2010, 2011, 2012, 2013, 2014, 2015, 2016 };
            foreach (int i in years)
            {
                data.Add(i.ToString());
            }
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 4; //2014 is the default year

        }

        private void ComboBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var yearValue = combobox.SelectedItem as string;
            var monthValue = months.Text;

            string fileStr = "OrderData/" + monthValue + yearValue + ".csv";

            if (!File.Exists(fileStr)) 
            {
                if (monthValue == "") return;
                MessageBox.Show(fileStr + " Not Available");
                List<Order> l = new List<Order>();
                lvDataBinding.ItemsSource = l;
                return;
            }

            switch (monthValue)
            {
                case "January":
                    IEnumerable<Order> ordernum = GetUniqOrd(fileStr, 0);
                    List<Order> ordlist = ordernum.Where(x => x != null).ToList<Order>();
                    lvDataBinding.ItemsSource = ordlist;
                    break;
                case "February":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 1).Where(x => x != null).ToList<Order>();
                    break;
                case "March":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 2).Where(x => x != null).ToList<Order>();
                    break;
                case "April":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 3).Where(x => x != null).ToList<Order>();
                    break;
                case "May":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 4).Where(x => x != null).ToList<Order>();
                    break;
                case "June":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 5).Where(x => x != null).ToList<Order>();
                    break;
                case "July":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 6).Where(x => x != null).ToList<Order>();
                    break;
                case "August":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 7).Where(x => x != null).ToList<Order>();
                    break;
                case "September":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 8).Where(x => x != null).ToList<Order>();
                    break;
                case "October":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 9).Where(x => x != null).ToList<Order>();
                    break;
                case "November":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 10).Where(x => x != null).ToList<Order>();
                    break;
                case "December":
                    lvDataBinding.ItemsSource = GetUniqOrd(fileStr, 11).Where(x => x != null).ToList<Order>();
                    break;
            }
        } 

        //choice of order month
        private void MonthBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> monthsData = new List<string>();
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (string s in months)
            {
                monthsData.Add(s);
            }
            var monthbox = sender as ComboBox;
            monthbox.ItemsSource = monthsData;
            monthbox.SelectedIndex = 0;
        }

        private void MonthBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            
            var monthValue = combobox.SelectedItem as string;
            var yearValue = years.Text;
            string fileStr = "OrderData/" + monthValue + yearValue + ".csv";

            if (!File.Exists(fileStr))
            {
                MessageBox.Show(fileStr + " Not Available");
                List<Order> l = new List<Order>();
                lvDataBinding.ItemsSource = l;
                return;
            }

            switch (monthValue)
            {
                case "January":
                            IEnumerable<Order> ordernum = GetUniqOrd(fileStr, 0);
                            List<Order> ordlist = ordernum.Where(x => x!=null).ToList<Order>();
                            lvDataBinding.ItemsSource = ordlist;
                            break;
                case "February":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,1).Where(x => x!=null).ToList<Order>();
                            break;
                case "March":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,2).Where(x => x != null).ToList<Order>();
                            break;
                case "April":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,3).Where(x => x != null).ToList<Order>();
                            break;
                case "May":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,4).Where(x => x != null).ToList<Order>();
                            break;
                case "June":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,5).Where(x => x != null).ToList<Order>();
                            break;
                case "July":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,6).Where(x => x != null).ToList<Order>();
                            break;
                case "August":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,7).Where(x => x != null).ToList<Order>();
                            break;
                case "September":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,8).Where(x => x != null).ToList<Order>();
                            break;
                case "October":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,9).Where(x => x != null).ToList<Order>();
                            break;
                case "November":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,10).Where(x => x != null).ToList<Order>();
                            break;
                case "December":
                            lvDataBinding.ItemsSource = GetUniqOrd(fileStr,11).Where(x => x != null).ToList<Order>();
                            break;
            }
        }

        public class Order
        {
            public int Month { get; set; }
            public string Territory { get; set; }
            public string Store { get; set; }
            public int CustID { get; set; }
            public string CustName { get; set; }
            public int OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public string AccNum { get; set; }
            public int OrderQuantity { get; set; }
            public string ProdNum { get; set; }
            public string ProdName { get; set; }
            public string UnitPrice { get; set; }
            public string UnitDiscount { get; set; }
            public string LineTotal { get; set; } //((UnitPrice - UnitDiscount) * OrderQuantity) = LineTotal

            public Order(int mon, string territory, string store, int custid, string custname, int orderid, DateTime orderdate, string accnum, int orderqty, string prodnum, string prodname,string unitprice, string unitdisc, string linetot)
            {
            Month = mon;
            Territory = territory;
            Store = store;
            CustID = custid;
            CustName = custname;
            OrderId = orderid;
            OrderDate = orderdate;
            AccNum = accnum;
            OrderQuantity = orderqty;
            ProdNum = prodnum;
            ProdName = prodname;
            UnitPrice = unitprice;
            UnitDiscount = unitdisc;
            LineTotal = linetot;
            }

            public override string ToString()
            {
                return this.Store + "\n " + this.OrderId;
            }
        }

        //Returns IEnumerable list of all order objects
        public IEnumerable<Order> GetOrd(string filename, int mon)
        {
            string[] lines = File.ReadAllLines(filename);
            string[] newlines = new string[lines.Length-1];
            for (int i = 1,j=0; i < lines.Length; i++,j++)
            {
                newlines[j] = lines[i];
            } 

            return newlines.Select(line =>
            {
                string[] data = line.Split(',');
                Hashtable ht = new Hashtable();
                if (!ht.ContainsKey(data[4]))
                {
                    ht.Add(data[4], data[1]);
                }
                    Order o = new Order(mon, data[0], data[1], 
                                        Convert.ToInt32(data[2]), data[3],
                                        Convert.ToInt32(data[4]), Convert.ToDateTime(data[5]),
                                        data[6], Convert.ToInt32(data[7]), data[8],
                                        data[9], data[10], data[11], data[12]);
                    return o;
                });
            }

        //Gets just the distinct orders(based on order id).
        public IEnumerable<Order> GetUniqOrd(string filename, int mon)
        {
            string[] lines = File.ReadAllLines(filename);
            Hashtable htab = new Hashtable();

            /*Creating a New array with just the Data
            skipping the Header*/
            string[] newlines = new string[lines.Length - 1];
            for (int i = 1, j = 0; i < lines.Length; i++, j++)
            {
                newlines[j] = lines[i];
            }

            //Returns an IEnumerable list of objects
            return newlines.Select(line =>
            {
                string[] data = line.Split(',');
                if (!htab.ContainsKey(data[4]))
                {
                    htab.Add(data[4], data[1]);
                    Order o = new Order(mon , data[0], data[1], 
                                        Convert.ToInt32(data[2]), data[3],
                                        Convert.ToInt32(data[4]),
                                        Convert.ToDateTime(data[5]), 
                                        data[6], Convert.ToInt32(data[7]),
                                        data[8], data[9], data[10],
                                        data[11], data[12]);
                    return o;
                }
                else
                    return null; //Nullifies the repeating orders.
            });
        }
/*
     public class SearchTextBox : Control {
         static SearchTextBox() {
             DefaultStyleKeyProperty.OverrideMetadata(
                 typeof(SearchTextBox),
                 new FrameworkPropertyMetadata(typeof(SearchTextBox)));
         }
     }
*/
        //Searches for a sales order in the selected month and year.
        public void Show_Search(object sender, RoutedEventArgs e)
        {
            string monStr = months.Text;
            string yearStr = years.Text;
            string searText = searchText.Text; 

            int val;
            switch (monStr)
            {
                case "January": val = 0;
                                break;
                case "February": val = 1;
                                break;
                case "March": val = 2;
                                break;
                case "April": val = 3;
                                break;
                case "May": val = 4;
                                break;
                case "June": val = 5;
                                break;
                case "July": val = 6;
                                break;
                case "August": val = 7;
                                break;
                case "September": val = 8;
                                break;
                case "October": val = 9;
                                break;
                case "November": val = 10;
                                break;
                case "December": val = 11;
                                break;
                default:        val = 12;
                                break;
            }

            bool available = false;
            if (searText != "")
            {
                string fileStr = "OrderData/" + monStr + yearStr +".csv";
                if (!File.Exists(fileStr))
                {
                    MessageBox.Show(fileStr + " Not Available");
                    return;
                }

                IEnumerable<Order> sameOrd = GetOrd(fileStr, val);
                List<Order> sameordList = new List<Order>();

                bool res = FindNumeric(searText);
                if (res == true) { 
                    foreach (Order o in sameOrd)
                    {
                        if (o.OrderId == Convert.ToInt32(searText))
                        {
                            sameordList.Add(new Order(val, o.Territory, o.Store, o.CustID, o.CustName,
                                                      o.OrderId, o.OrderDate, o.AccNum, o.OrderQuantity,
                                                      o.ProdNum, o.ProdName, o.UnitPrice, o.UnitDiscount, o.LineTotal));
                            available=true;
                            break;
                        }
                    }
                    lvDataBinding.ItemsSource = sameordList;
                    if (available == false)
                    {
                        MessageBox.Show("No such order in " + monStr);
                    }
                }
                else MessageBox.Show("Please enter a numeric Order ID.");
            }
        }

        //Displays details of all sub orders, with the same order id.
        public void Show_Details(object sender, RoutedEventArgs e)
        {
            ListViewItem item = ItemsControl.ContainerFromElement(lvDataBinding, e.OriginalSource as DependencyObject) as ListViewItem;

            if (item != null)
            {
                Order o = (Order)item.Content;
                int id = o.OrderId;
                string monVal;

                switch (o.Month)
                {
                    case 0: monVal = "January";
                                     break;
                    case 1: monVal = "February";
                                     break;
                    case 2: monVal = "March";
                                     break;
                    case 3: monVal = "April";
                                     break;
                    case 4: monVal = "May";
                                     break;
                    case 5: monVal = "June";
                                     break;
                    case 6: monVal = "July";
                                     break;
                    case 7: monVal = "August";
                                     break;
                    case 8: monVal = "September";
                                     break;
                    case 9: monVal = "October";
                                     break;
                    case 10: monVal = "November";
                                     break;
                    case 11: monVal = "December";
                                     break;
                    default: monVal = "January";
                                     break;
                }

                string finalStr =   "Territory - " + o.Territory +
                                    ";   Store Name - " + o.Store +
                                    ";   Customer ID - " + o.CustID +
                                    ";   Customer Name - " + o.CustName +
                                    ";   Sales Order ID - " + o.OrderId +
                                    ";   Order Date - " + o.OrderDate +
                                    ";  Account Number - " + o.AccNum +
                                    " \n\n \t\t\t\t\t Order Item Details";

                double lineTotal=0.0;

                string fileStr = "OrderData/" + monVal + "2014.csv";
                IEnumerable<Order> sameOrd = GetOrd(fileStr, o.Month).Where(x => x.OrderId == id);
                List<Order> sameordList = new List<Order>();
                foreach (Order or in sameOrd)
                {
                    sameordList.Add(or);
                    lineTotal += Convert.ToDouble(or.LineTotal);
                }
                
                foreach (Order or in sameordList)
                {
                    finalStr +=     "\n\n   Order Qty                : " + or.OrderQuantity +
                                      "\n   Product Number     : " + or.ProdNum +
                                      "\n   Product Name         : " + or.ProdName +
                                      "\n   Unit Price                 : " + or.UnitPrice +
                                      "\n   Unit Price Discount  : " + or.UnitDiscount +
                                      "\n   Line Total                 : " + o.LineTotal;
                }
                string saleStr = lineTotal.ToString();
              //  string sendstr = "Total Sale Price of the order : " + saleStr + "\n\n ORDER INFO\n" + finalStr;
                Window2 w = new Window2();
              //  w.RaiseCustomEvent += new EventHandler<CustomEventArgs>(w_RaiseCustomEvent);
                w.Show();
                
   
              //  MessageBox.Show("Total Sale Price of the order : "+ saleStr + "\n\n ORDER INFO\n" + finalStr);
            }

        }


        //Utility function to check if input has only integers.
        public static bool FindNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }


    }


}
