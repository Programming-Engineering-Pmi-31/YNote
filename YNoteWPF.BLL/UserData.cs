﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;
using YNoteWPF.DAL;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL
{
    public class UserData
    {
        YNoteDbContext db = new YNoteDbContext();
        string email;
        string password;
        public string ValidationErrors { get; private set; }
        public bool Verification(string Email, string Password)
        {
            email = Email;
            password = Password;

            IQueryable<UserEntity> users = from user in db.Users
                                           where user.Email == email && user.Password == password
                                           select user;
            if (users.Any())
            {
                // list has at least one item
                return true;
            }
            return false;
        }
        public void SaveChangesForUser()
        {
            //db.SaveChanges();
        }
        public void RegisterWithoutAllNecessaryTests(List<string> parameters, Button regButton)
        {
            // tests only on password equality and check if the user with such email exists to prevent
            // of adding to db the same user (with such email)
            if (parameters[4] != parameters[5])
            {
                throw new Exception("Passwords do not match");
            }
            UserEntity user = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = parameters[0],
                Surname = parameters[1],
                Nickname = parameters[2],
                Email = parameters[3],
                Password = parameters[4]
            };
            var inTable = db.Users.Where(x => x.Email == user.Email);
            if (!inTable.Any())
            {
                db.Users.Add(user);
                db.SaveChanges();
                regButton.BorderThickness = new System.Windows.Thickness(2);
                regButton.BorderBrush = Brushes.Green;
            }
            else
            {
                regButton.BorderThickness = new System.Windows.Thickness(2);
                regButton.BorderBrush = Brushes.Red;
            }
        }
        public void Register(List<string> parameters, Button regButton)
        {
            FieldsConditions fields = new FieldsConditions();
            string errors = "";
            if (fields.CheckOnValidation(parameters))
            {
                UserEntity user = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = parameters[0],
                    Surname = parameters[1],
                    Nickname = parameters[2],
                    Email = parameters[3],
                    Password = parameters[4]
                };
                var emailInTable = db.Users.Where(x => x.Email == user.Email);
                var nickInTable = db.Users.Where(x => x.Nickname == user.Nickname);
                if (!emailInTable.Any() && !nickInTable.Any())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    regButton.BorderThickness = new System.Windows.Thickness(2);
                    regButton.BorderBrush = Brushes.Green;
                }
                else
                {
                    regButton.BorderThickness = new System.Windows.Thickness(2);
                    regButton.BorderBrush = Brushes.Red;
                    errors = "Email or nick already exists";
                }
            }
            else
            {
                regButton.BorderThickness = new System.Windows.Thickness(2);
                regButton.BorderBrush = Brushes.Red;
            }
            if (errors != "")
            {
                errors = fields.Errors;
            }
        }
        public UserDTO GetUser()
        {
            UserDTO user = new UserDTO();
            if (Verification(email, password))
            {
                IEnumerable<UserEntity> users = from usr in db.Users
                                                where usr.Email == email && usr.Password == password
                                                select usr;
                user.Id = users.First().Id;
                user.Name = users.First().Name;
                user.Surname = users.First().Surname;
                user.Nickname = users.First().Nickname;
                user.Email = users.First().Email;
                user.Password = users.First().Password;
<<<<<<< HEAD
                return user;
=======
>>>>>>> 38d47fb1ade10b41ae7bb18551066b2dea336e73
            }
            return user;
        }
    }
}
