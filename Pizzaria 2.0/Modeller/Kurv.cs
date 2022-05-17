using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria_2._0.Modeller
{
    class Kurv
    {
        public ObservableCollection<Pizza> PizzaIKurv = new ObservableCollection<Pizza>();

        public Kurv()
        {

        }

        //Funktion der udregner prisen af kurven.
        public double PrisAfKurv()
        {
            double temp = 0;
            foreach (Pizza p in PizzaIKurv)
            {
                temp += p._ppris;
            }
            return temp;
        }

        //Funktion der tilføjer den valgte pizza til kurven.
        public void TilføjTilKurv(Pizza ipizza)
        {
            PizzaIKurv.Add(ipizza);
        }

        //Funktion der fjerner den valgte pizza fra kurven.
        public void FjernFraKurv(int Kurveidddd)
        {
            //Pizza p = null;

            foreach (var piz in PizzaIKurv)
            {
                if (piz._KurvID == Kurveidddd)
                {
                PizzaIKurv.Remove(piz);
                break;
                }
            }
        }
    }

}
