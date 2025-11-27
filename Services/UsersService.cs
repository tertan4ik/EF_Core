<<<<<<< HEAD
﻿using System.Collections.ObjectModel;
using System.Linq;
using WpfApp_DataBinding_EF.Data;
=======
﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
>>>>>>> b14fbb8 (complete prac 13)
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class UsersService
    {
<<<<<<< HEAD
        private readonly AppDbContext _db = new AppDbContext();
=======
        private readonly Data.AppDbContext _db = BaseDbService.Instance.Context;
>>>>>>> b14fbb8 (complete prac 13)

        public ObservableCollection<User> Users { get; set; } = new();
        public User? SelectedUser { get; set; }

        public UsersService()
        {
<<<<<<< HEAD
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
=======
            GetAll();
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users
                .Include(u => u.Role)
                .Include(u => u.Userprofile)
                .AsNoTracking()
                .ToList();

            Users.Clear();
            foreach (var u in users)
                Users.Add(u);
        }

        // ---------------- ДОБАВЛЕНИЕ ----------------

        public void AddUser(User formUser)
        {
            // создаём ОТДЕЛЬНУЮ сущность для EF, не трогаем объект, привязанный к форме
            var entity = new User
            {
                Login = formUser.Login,
                Name = formUser.Name,
                Email = formUser.Email,
                Password = formUser.Password,
                CreatedAt = formUser.CreatedAt,

                Role_Id = formUser.Role != null ? formUser.Role.Id : formUser.Role_Id
            };

            // профиль
            if (formUser.Userprofile != null)
            {
                var p = formUser.Userprofile;

                entity.Userprofile = new UserProfile
                {
                    AvatarUrl = p.AvatarUrl,
                    Name = p.Name,
                    Phone = p.Phone,
                    Birthday = p.Birthday,
                    Bio = p.Bio
                };
            }

            _db.Users.Add(entity);
            _db.SaveChanges();

            // подгружаем роль для отображения
            _db.Entry(entity).Reference(u => u.Role).Load();

            Users.Add(entity);
        }

        // ---------------- ОБНОВЛЕНИЕ ----------------

        public void UpdateUser(User formUser)
        {
            // вытаскиваем существующий объект из БД
            var entity = _db.Users
                .Include(u => u.Userprofile)
                .Include(u => u.Role)
                .First(u => u.Id == formUser.Id);

            // обновляем поля
            entity.Login = formUser.Login;
            entity.Name = formUser.Name;
            entity.Email = formUser.Email;
            entity.Password = formUser.Password;
            entity.CreatedAt = formUser.CreatedAt;
            entity.Role_Id = formUser.Role != null ? formUser.Role.Id : formUser.Role_Id;

            // профиль
            var p = formUser.Userprofile;
            if (p != null)
            {
                if (entity.Userprofile == null)
                {
                    entity.Userprofile = new UserProfile
                    {
                        Id = entity.Id,
                        AvatarUrl = p.AvatarUrl,
                        Name = p.Name,
                        Phone = p.Phone,
                        Birthday = p.Birthday,
                        Bio = p.Bio
                    };
                    _db.UserProfiles.Add(entity.Userprofile);
                }
                else
                {
                    entity.Userprofile.AvatarUrl = p.AvatarUrl;
                    entity.Userprofile.Name = p.Name;
                    entity.Userprofile.Phone = p.Phone;
                    entity.Userprofile.Birthday = p.Birthday;
                    entity.Userprofile.Bio = p.Bio;
                }
            }

            _db.SaveChanges();

            // заново подгружаем роль
            _db.Entry(entity).Reference(u => u.Role).Load();

            // обновляем объект в ObservableCollection
            var idx = Users.IndexOf(Users.First(u => u.Id == entity.Id));
            if (idx >= 0)
                Users[idx] = entity;
        }

        // ---------------- УДАЛЕНИЕ ----------------

        public void RemoveUser(User user)
        {
            _db.Users.Remove(user);
            if (Commit() > 0 && Users.Contains(user))
                Users.Remove(user);
        }

        // ---------------- ПРОВЕРКА УНИКАЛЬНОСТИ ----------------

        public bool IsLoginUnique(string login, int currentId = 0)
        {
            var lower = login.ToLower();
            return _db.Users.Any(u => u.Login.ToLower() == lower && u.Id != currentId);
>>>>>>> b14fbb8 (complete prac 13)
        }

        public bool IsEmailUnique(string email, int currentId = 0)
        {
<<<<<<< HEAD
            return _db.Users.Any(u => u.Email.ToLower() == email.ToLower() && u.Id != currentId);
=======
            var lower = email.ToLower();
            return _db.Users.Any(u => u.Email.ToLower() == lower && u.Id != currentId);
>>>>>>> b14fbb8 (complete prac 13)
        }
    }
}
