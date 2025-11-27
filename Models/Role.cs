using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_DataBinding_EF.Models
{
    public class Role:INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

<<<<<<< HEAD
=======

>>>>>>> b14fbb8 (complete prac 13)
        private string _title = "";
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<User> _user;
<<<<<<< HEAD
        public ObservableCollection<User> User
=======
        public ObservableCollection<User> Users
>>>>>>> b14fbb8 (complete prac 13)
        {
            get => _user;
            set
            {
                _user = value;
            }
        }





        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
