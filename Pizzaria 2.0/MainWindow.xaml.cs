using Newtonsoft.Json;
using Pizzaria_2._0.DAL;
using Pizzaria_2._0.Modeller;
using Pizzaria_2._0.Modeller.ViewModels;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzaria_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            PizzakurvViewModel vm = new PizzakurvViewModel();
            DataContext = vm;
        } 

        private void Velkommen_Click(object sender, RoutedEventArgs e)
        {
            BestillingsVindue bestillingsVindue = new BestillingsVindue();
            bestillingsVindue.Show();




            //PizzaDAL dal = new PizzaDAL();
            //dal.SavePizzas();  

        }
    }
}
