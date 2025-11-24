using System;
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
                    CreatedAt = DateTime.Now
                };
                _isEdit = false;
            }
            else
            {
                _user = editUser;
                _isEdit = true;
            }

            DataContext = _user;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (_user.CreatedAt < DateTime.Today)
            {
                MessageBox.Show("Дата создания не может быть раньше сегодняшней");
                return;
            }

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

            if (_isEdit)
                _service.UpdateUser(_user);
            else
                _service.AddUser(_user);

            NavigationService.GoBack();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
