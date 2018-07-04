using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;
using System.Collections.Generic;
namespace calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        //private void empList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //int k = depList.SelectedIndex;
        //    XmlDataProvider xdp = (XmlDataProvider)this.FindResource("financeProvider");
        //    Binding b = new Binding();
        //    b.Source = xdp;
        //    //b.XPath = $"employee[@dep={k}]";//предикаты в квадратных скобках

        //   // empList.SetBinding(ListBox.ItemsSourceProperty, b);

        //}

        private void Banks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string path = @"..\..\Data\testxml.xml";
            //XDocument doc = XDocument.Load(path);
            //XElement root = doc.XPathSelectElement($"/source/organizations/organization");
            //var lst = root.Elements("currencies");
            //XElement elem = new XElement("c",
            //        new XAttribute("id", "UAH"),
            //        new XAttribute("br", "1"),
            //        new XAttribute("ar", "1"));
            //var last = lst.LastOrDefault();
            //foreach (var item in lst)
            //{
            //    (item as XElement).Add(elem);
            //}
            //doc.Save(path);
            

            string k = (Banks.SelectedItem as XmlNode).Attributes["id"].Value;
            XmlDataProvider xdp = (XmlDataProvider)this.FindResource("financeProvider");
            
            Binding b = new Binding();
  
            b.Source = xdp;
 
            b.XPath = $"organizations/organization[@id='{k}']/currencies/c[@id]";
            

           
            ListCurrencies1.SetBinding(ListBox.ItemsSourceProperty, b);
            //  ListCurrencies2.SetBinding(ListBox.ItemsSourceProperty, b);

        }

        private void ListCurrencies2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           Calc();

        }

        private void ListCurrencies1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Calc();
        }

        private void Buy_Checked(object sender, RoutedEventArgs e)
        {
            Calc();
        }

        private void Sell_Checked(object sender, RoutedEventArgs e)
        {
            Calc();
        }
        private void Calc()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            double num;
            string k;

            try
            {
              
                TextBox2.Text = string.Empty;
                num = double.Parse(TextBox1.Text);
                k = (ListCurrencies1.SelectedItem as XmlNode).Attributes[Buy.IsChecked == true ? "br" : "ar"].Value;
            }
            catch (Exception)
            {

                return;
            }

        
            double d = (num * double.Parse(k));
            TextBox2.Text = d.ToString();
        }
    }
}
