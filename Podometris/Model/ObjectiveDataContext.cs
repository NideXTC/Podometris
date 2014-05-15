using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Podometris.Model
{
    class ObjectiveDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public ObjectiveDataContext(string connectionString):base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<ObjectiveItems> Items;


        [Table]
        public class ObjectiveItems : INotifyPropertyChanged, INotifyPropertyChanging
        {

            // Define ID: private field, public property, and database column.
            private int _Id;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int Id
            {
                get { return _Id; }
                set
                {
                    if (_Id != value)
                    {
                        NotifyPropertyChanging("Id");
                        _Id = value;
                        NotifyPropertyChanged("Id");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private string _km;

            [Column]
            public string KM
            {
                get { return _km; }
                set
                {
                    if (_km != value)
                    {
                        NotifyPropertyChanging("ItemName");
                        _km = value;
                        NotifyPropertyChanged("ItemName");
                    }
                }
            }

            // Define completion value: private field, public property, and database column.
            private bool _time;

            [Column]
            public bool Time
            {
                get { return _time; }
                set
                {
                    if (_time != value)
                    {
                        NotifyPropertyChanging("IsComplete");
                        _time = value;
                        NotifyPropertyChanged("IsComplete");
                    }
                }
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            // Used to notify that a property changed
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            // Used to notify that a property is about to change
            private void NotifyPropertyChanging(string propertyName)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }

            #endregion
        }


    }
}
