<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
=======
﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
>>>>>>> b14fbb8 (complete prac 13)
using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class MainPage : Page
    {
        public UsersService Service { get; set; } = new UsersService();

        public MainPage()
        {
            InitializeComponent();
            DataContext = Service;
        }

        private void GotoAdd(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            NavigationService.Navigate(new UserFormPage(Service, null));
=======
            NavigationService?.Navigate(new UserFormPage(Service, null));
>>>>>>> b14fbb8 (complete prac 13)
        }

        private void GotoEdit(object sender, RoutedEventArgs e)
        {
            if (Service.SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

<<<<<<< HEAD
            NavigationService.Navigate(new UserFormPage(Service, Service.SelectedUser));
=======
            NavigationService?.Navigate(new UserFormPage(Service, Service.SelectedUser));
>>>>>>> b14fbb8 (complete prac 13)
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (Service.SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

<<<<<<< HEAD
            if (MessageBox.Show("Удалить выбранного пользователя?",
=======
            if (MessageBox.Show("Удалить пользователя?",
>>>>>>> b14fbb8 (complete prac 13)
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Service.RemoveUser(Service.SelectedUser);
            }
        }
<<<<<<< HEAD
    }
}

=======
        private void GotoRoles(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RolesPage());
        }
    }
}
>>>>>>> b14fbb8 (complete prac 13)
