using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.ComponentModel;



namespace WindowsFormsApplication3
{
    class Person 
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get { return id; }
            set { id = value; }
            // set { id = value; this.OnNotifyPropertyChanged("Id"); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

   /*      public event NotifyPropertyChangedHandler NotifyPropertyChanged;

        protected virtual void OnNotifyPropertyChanged(string propertyName)
        {
            if (NotifyPropertyChanged != null)
            {
                NotifyPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } */
    }
}
