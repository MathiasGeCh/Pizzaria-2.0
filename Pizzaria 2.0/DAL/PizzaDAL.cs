using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria_2._0.Modeller;
using System.Collections.ObjectModel;

namespace Pizzaria_2._0.DAL
{
    public class PizzaDAL
    {
        [JsonProperty]
        private ObservableCollection<Pizza> Pizzaer;
        [JsonProperty]
        private ObservableCollection<Ingredienser> Toppings;
        [JsonProperty]
        private ObservableCollection<Bunde> MineBunde;



        public PizzaDAL()
        {
            
        }
        

        private void LoadData()
        {
            //Henter Dataen der er gemt på min JsonFil
            var json = File.ReadAllText("data.json");
            var data = JsonConvert.DeserializeObject<PizzaDAL>(json);
            Pizzaer = data.Pizzaer;
            Toppings = data.Toppings;
            MineBunde = data.MineBunde;

        }
        public ObservableCollection<Pizza> GetAppPizzas()
        {
            //Fylder listen med Pizzaer
            if (Pizzaer == null)
            {
                LoadData();
            }
            return Pizzaer;
        }


        public ObservableCollection<Pizza> GetPizzas()
        {
            return new ObservableCollection<Pizza>();
        }
        // returner en Pizza ud fra ID - dette er en kopi!
        public Pizza GetPizzaById(int id)
        {
            Pizza p = null;
            foreach (var item in Pizzaer)
            {
                if (item._pid == id)
                {
                    p = item;
                }
            }
            if (p == null)
            {
                return null;
            }

            LoadData();



            //laver en ny Pizzaa - den vi returnerer herfra.
            Pizza resultat = new Pizza();
            resultat.Pstørrelse = p.Pstørrelse;

            // Kopiere alle simple typer.
            resultat._pid = p._pid;
            resultat._pnavn = p._pnavn;

            //Laver en ny bund som en kopi af den originale bund
            resultat.Bund.Add(new Bunde()
            {
                _bid = p.Bund[0]._bid,
                _bnavn = p.Bund[0]._bnavn,
                _bpris = p.Bund[0]._bpris

            });



            // Ny liste af toppings
            resultat.Toppings = new ObservableCollection<Ingredienser>();

            // Løber de originale toppings igennem og kopiere alle parametre til nye toppings             
            foreach (var top in p.Toppings)
            {
                Ingredienser i = new Ingredienser();
                i._iid = top._iid;
                i._inavn = top._inavn;
                i._ipris = top._ipris;
                resultat.Toppings.Add(i);
            }
            // returnere den nye pizza
            return resultat;

        }




             //Gemmer Data til min Jason Fil, skal gøres ved et btnclick
            /* SavePizzas
            public void SavePizzas()
            {

                MineBunde.Add(new Bunde()
                {
                    _bnavn = "HvedeBund",
                    _bpris = 15,
                    _bid = 1,
                });
                MineBunde.Add(new Bunde()
                {
                    _bnavn = "Ølandshvede",
                    _bpris = 20,
                    _bid = 2,

                });

                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Ost",
                    _ipris = 7,
                    _iid = 1,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Tomatsovs",
                    _ipris = 5,
                    _iid = 2,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Oksekød",
                    _ipris = 8,
                    _iid = 3,

                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Kebab",
                    _ipris = 8,
                    _iid = 4,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Bearnaise",
                    _ipris = 6,
                    _iid = 5,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Chilli",
                    _ipris = 5,
                    _iid = 6,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Hvidløg",
                    _ipris = 5,
                    _iid = 7,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Oregano",
                    _ipris = 5,
                    _iid = 8,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Soltørret Tomat",
                    _ipris = 5,
                    _iid = 9,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Kartoffel",
                    _ipris = 6,
                    _iid = 10,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Rosmarin",
                    _ipris = 6,
                    _iid = 11,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Mozzarella",
                    _ipris = 8,
                    _iid = 12,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Parmesan",
                    _ipris = 8,
                    _iid = 13,
                });
                Toppings.Add(new Ingredienser()
                {
                    _inavn = "Blåskimmel",
                    _ipris = 8,
                    _iid = 14
                });

                Pizzaer.Add(new Pizza()
                {
                    _pnavn = "Nummer 1",
                    _pid = 1,
                    Pstørrelse = Pizza.PizzaStørrelse.mellem,
                    Bund = new ObservableCollection<Bunde>
                    {
                        new Bunde()
                        {
                            _bnavn = "Hvede",
                            _bpris = 10,
                            _bid = 1
                        }
                    },
                    Toppings = new ObservableCollection<Ingredienser>
                    {
                        new Ingredienser()
                        {
                            _inavn = "Ost",
                            _ipris = 7,
                            _iid = 1,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Tomatsovs",
                            _ipris = 5,
                            _iid = 2,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Oksekød",
                            _ipris = 8,
                            _iid = 3,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Kebab",
                            _ipris = 8,
                            _iid = 4,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Bearnaise",
                            _ipris = 6,
                            _iid = 5,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Chilli",
                            _ipris = 5,
                            _iid = 6,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Hvidløg",
                            _ipris = 5,
                            _iid = 7,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Oregano",
                            _ipris = 5,
                            _iid = 8,

                        },
                    }

                });
                Pizzaer.Add(new Pizza()
                {
                    _pnavn = "Nummer 2",
                    _pid = 2,
                    Pstørrelse = Pizza.PizzaStørrelse.mellem,
                    Bund = new ObservableCollection<Bunde>
                    {
                        new Bunde()
                        {
                            _bnavn = "ØlandsHvede",
                            _bpris = 20,
                            _bid = 2
                        }
                    },
                    Toppings = new ObservableCollection<Ingredienser>
                    {
                        new Ingredienser()
                        {
                            _inavn = "Ost",
                            _ipris = 7,
                            _iid = 1,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Tomatsovs",
                            _ipris = 5,
                            _iid = 2,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Soltørret Tomat",
                            _ipris = 5,
                            _iid = 9,

                        },
                        new Ingredienser()
                        {
                            _inavn = "Kartoffel",
                            _ipris = 6,
                            _iid = 10,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Rosmarin",
                            _ipris = 6,
                            _iid = 11,
                        }
                    }
                });
                Pizzaer.Add(new Pizza()
                {
                    _pnavn = "Nummer 3",
                    _pid = 3,
                    Pstørrelse = Pizza.PizzaStørrelse.mellem,
                    Bund = new ObservableCollection<Bunde>
                    {
                        new Bunde()
                        {
                            _bnavn = "Hvede",
                            _bpris = 10,
                            _bid = 1
                        }
                    },

                    Toppings = new ObservableCollection<Ingredienser>
                    {
                        new Ingredienser()
                        {
                            _inavn = "Ost",
                            _ipris = 7,
                            _iid = 1,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Tomatsovs",
                            _ipris = 5,
                            _iid = 2,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Mozzarella",
                            _ipris = 8,
                            _iid = 12,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Parmesan",
                            _ipris = 8,
                            _iid = 13,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Blåskimmel",
                            _ipris = 8,
                            _iid = 14,
                        },
                        new Ingredienser()
                        {
                            _inavn = "Oregano",
                            _ipris = 5,
                            _iid = 8,
                        },
                    }
                });
                var data = JsonConvert.SerializeObject(this);
                File.WriteAllText("data.json", data);
            }
            */

        }
}

        