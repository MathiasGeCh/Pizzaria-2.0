using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Pizzaria_2._0.Modeller;
using Pizzaria_2._0.Modeller.ViewModels;
using Pizzaria_2._0.DAL;


namespace Pizzaria_2._0
{
    /// <summary>
    /// Interaction logic for BestillingsVindue.xaml
    /// </summary>
    public partial class BestillingsVindue : Window
    {
        
        PizzakurvViewModel vm;

        public BestillingsVindue()
        {
            InitializeComponent();
            vm = new PizzakurvViewModel();
            DataContext = vm;     
        }

        private void Btn_Tilføj_Click(object sender, RoutedEventArgs e)
        {
            vm.GetPizzaFromID(vm.SelectedItemMenu.ID);
        }

        private void Btn_Fjern_Click(object sender, RoutedEventArgs e)
        {
            vm.SletPizza();
        }
    }
}
