using System.Collections.ObjectModel;
using System.Linq;
using WpfApp_DataBinding_EF.Data;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class UsersService
    {
        private readonly AppDbContext _db = new AppDbContext();

        public ObservableCollection<User> Users { get; set; } = new();
        public User? SelectedUser { get; set; }

        public UsersService()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            Users.Clear();
            foreach (var u in _db.Users.ToList())
                Users.Add(u);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _db.Users.Remove(user);
            if (_db.SaveChanges() > 0)
                Users.Remove(user);
        }

        public bool IsLoginUnique(string login, int currentId = 0)
        {
            return _db.Users.Any(u => u.Login.ToLower() == login.ToLower() && u.Id != currentId);
        }

        public bool IsEmailUnique(string email, int currentId = 0)
        {
            return _db.Users.Any(u => u.Email.ToLower() == email.ToLower() && u.Id != currentId);
        }
    }
}
