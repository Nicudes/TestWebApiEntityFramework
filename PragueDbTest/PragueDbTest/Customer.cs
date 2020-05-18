using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace PragueDbTest
{
    [Table("Customers")]
    public class Customer :INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        { get
            { return _id; } 
          set
            { 
              this._id = value;  
              OnPropertyChanged(nameof(Id));
            }

        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set 
            { 
                this._Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { 
                this._lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }

    }
}
