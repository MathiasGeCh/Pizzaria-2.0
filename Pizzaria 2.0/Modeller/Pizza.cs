using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria_2._0.Modeller
{
    public class Pizza
    {
        public enum PizzaStørrelse
        {
            lille = 1,
            mellem = 2,
            stor = 3,
        }
        public string _pnavn { get; set; }
        public ObservableCollection<Ingredienser> Toppings { get; set; } = new ObservableCollection<Ingredienser>();
        public ObservableCollection<Bunde> Bund { get; set; } = new ObservableCollection<Bunde>();
        public PizzaStørrelse Pstørrelse { get; set; }
        public int _pid { get; set; }
        public int _KurvID { get; set; }
        public double _ppris
        {
            get
            {
                double Pris = 10;
                foreach (var item in Toppings)
                {
                    Pris += item._ipris;
                }
                Pris *= (int)Pstørrelse;
                return Pris;
                
            }
            set { }

        }

    }


    
    
}
