using System;
<<<<<<< HEAD
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
>>>>>>> b14fbb8 (complete prac 13)
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class UserFormPage : Page
    {
        private readonly UsersService _service;
        private readonly bool _isEdit;
        private readonly User _user;

        public UserFormPage(UsersService service, User? editUser)
        {
            InitializeComponent();

            _service = service;

            if (editUser == null)
            {
                _user = new User
                {
<<<<<<< HEAD
                    CreatedAt = DateTime.Now
=======
                    CreatedAt = DateTime.Now,
                    Userprofile = new UserProfile()
>>>>>>> b14fbb8 (complete prac 13)
                };
                _isEdit = false;
            }
            else
            {
                _user = editUser;
<<<<<<< HEAD
=======

                if (_user.Userprofile == null)
                    _user.Userprofile = new UserProfile { Id = _user.Id };

>>>>>>> b14fbb8 (complete prac 13)
                _isEdit = true;
            }

            DataContext = _user;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
=======
            // простые проверки, кроме ValidationRule
            if (_user.Role == null)
            {
                MessageBox.Show("Выберите роль");
                return;
            }

            _user.Role_Id = _user.Role.Id;

            if (_service.IsLoginUnique(_user.Login, _user.Id))
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

            if (_service.IsEmailUnique(_user.Email, _user.Id))
            {
                MessageBox.Show("Такой email уже существует");
                return;
            }

>>>>>>> b14fbb8 (complete prac 13)
            if (_user.CreatedAt < DateTime.Today)
            {
                MessageBox.Show("Дата создания не может быть раньше сегодняшней");
                return;
            }

<<<<<<< HEAD
            if (_service.IsLoginUnique(_user.Login, _user.Id))
            {
                MessageBox.Show("Такой логин уже есть");
                return;
            }

            if (_service.IsEmailUnique(_user.Email, _user.Id))
            {
                MessageBox.Show("Такой email уже есть");
                return;
            }

=======
            if(_user.Name==null||_user.Email==null||_user.Password==null)
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }
>>>>>>> b14fbb8 (complete prac 13)
            if (_isEdit)
                _service.UpdateUser(_user);
            else
                _service.AddUser(_user);

<<<<<<< HEAD
            NavigationService.GoBack();
=======
            NavigationService?.GoBack();
>>>>>>> b14fbb8 (complete prac 13)
        }

        private void Back(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            NavigationService.GoBack();
=======
            NavigationService?.GoBack();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

>>>>>>> b14fbb8 (complete prac 13)
        }
    }
}
