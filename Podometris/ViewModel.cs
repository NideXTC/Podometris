using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podometris
{
    public class ViewModel
    {
        public ObservableCollection<Model> Collection { get; set; }
        public ViewModel()
        {
            Collection = new ObservableCollection<Model>();
            GenerateDatas();
        }

        private ObservableCollection<Stats> Read()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("stats"))
            {
                List<Stats> myList = new List<Stats>();
                myList = (List<Stats>)IsolatedStorageSettings.ApplicationSettings["stats"];
                ObservableCollection<Stats> myObs = new ObservableCollection<Stats>(myList);
                return myObs;
            }
            else
            {
                return new ObservableCollection<Stats>();
            }

        }

        private void GenerateDatas()
        {
            ObservableCollection<Stats> data = this.Read();
            double i = 0; 
            foreach(Stats v in data){
                this.Collection.Add(new Model(i, Math.Round(v.Km, 2)));
                i++;
            }
           
        }
    }

}
