using System;
using Pizzaria_2._0.DAL;
using Pizzaria_2._0.Modeller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria_2._0.Modeller.ViewModels
{
    public class PizzakurvViewModel : INotifyPropertyChanged
    {
        Kurv VareKurv;
        int KurvIDTaeller;

        public ObservableCollection<Pizza> Kurvpizza { get; set; }
        //ViewModel til vise objekter på menuen (skal bindes til den der er public)
        private ObservableCollection<PizzaDisplayer> _menu;
        public ObservableCollection<PizzaDisplayer> Menu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                OnPropertyChanged(nameof(Menu));
            }
        }


        //ViewModel der skal vise prisen
        private double _ppris;
        public double Pris
        {
            get { return _ppris; }
            set
            {
                _ppris = value;
                OnPropertyChanged(nameof(Pris));

            }

        }

        //Skal vise de varer der er i Kurven
        private ObservableCollection<KurvDisplayer> _pizzakurv;

        public ObservableCollection<KurvDisplayer> Pizzakurv
        {
            get { return _pizzakurv; }
            set
            {
                _pizzakurv = value;
                OnPropertyChanged(nameof(Pizzakurv));
            }
        }


        
        //gør så du kan vælge det item der bliver trykket på.
        private KurvDisplayer _selectedItemKurv;

        public KurvDisplayer SelectedItemKurv
        {
            get { return _selectedItemKurv; }
            set
            {
                _selectedItemKurv = value;
                OnPropertyChanged(nameof(SelectedItemKurv));
            }
        }

        //ViewModel der gør at jeg kan få fat i den selectedItem
        private PizzaDisplayer _selectedItemMenu;

        public PizzaDisplayer SelectedItemMenu
        {
            get { return _selectedItemMenu; }
            set { _selectedItemMenu = value;
                OnPropertyChanged(nameof(SelectedItemMenu));
            }
        }

        //Fjerner en pizza ud fra ID, samt opdaterer prisen af kurven.
        public void SletPizza()
        {
            if (SelectedItemKurv != null) { 
            VareKurv.FjernFraKurv(SelectedItemKurv.KurvID);
                foreach (var piz in Pizzakurv)
                {
                    if (piz.KurvID == SelectedItemKurv.KurvID)
                    {
                        Pizzakurv.Remove(piz);
                        break;
                    }
                }
            }
            Pris = VareKurv.PrisAfKurv();
        }
        

        //tager fat i en pizza ud fra pizzaens ID, samt tilføjer den til kurv og opdaterer pris af kurv
        public void GetPizzaFromID(int PizzaID)
       
        {
            Pizza p = dal.GetPizzaById(PizzaID);
            Kurvpizza.Add(p);
            

                KurvDisplayer pizz = new KurvDisplayer
                {
                    KurvBeskrivelse = $" {p._pnavn} Pizza med {p.Bund[0]._bnavn}bund, og toppings bestående af "
                };
                foreach (Ingredienser top in p.Toppings)
                {
                    pizz.KurvBeskrivelse += top._inavn + ", ";
                }
                pizz.KurvID = KurvIDTaeller;
                p._KurvID = KurvIDTaeller;
                VareKurv.TilføjTilKurv(p);
                Pizzakurv.Add(pizz);
                Pris = VareKurv.PrisAfKurv();

                KurvIDTaeller++;
          
        }

        //Min constructor.
        private PizzaDAL dal;
        public PizzakurvViewModel()
        {
            dal = new PizzaDAL();
            Menu = new ObservableCollection<PizzaDisplayer>();
            Kurvpizza = new ObservableCollection<Pizza>();
            Pizzakurv = new ObservableCollection<KurvDisplayer>();
            FillPizzaList();
            VareKurv = new Kurv();
            KurvIDTaeller = 0;
        }


        //Fylder min liste med Pizzaer fra min Json og tilføjer dem til menuen på brugerfladen. 
        private void FillPizzaList()
        {
            
            //Metode til at fylde listen med pizzaer fra min JsonFil, der viser pizzaens info, samt laver det om til noget jeg kan binde til.
            foreach (var piz in dal.GetAppPizzas())
            {

                PizzaDisplayer p = new PizzaDisplayer
                {
                    Beskrivelse = $"{piz._ppris}kr,-  {piz._pnavn} Pizza med {piz.Bund[0]._bnavn}bund, og toppings bestående af "
                };
                foreach (var top in piz.Toppings)
                {
                    p.Beskrivelse += top._inavn + ", ";
                }
                p.ID = piz._pid;
                Menu.Add(p);

            }
        }


   

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
    }


}
