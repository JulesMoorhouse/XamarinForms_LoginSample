﻿using System;
using SQLite;

namespace LoginSample.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool CheckInformation()
        {
            if ((this.Username != null && !this.Username.Equals("")) &&
                (this.Password != null && !this.Password.Equals("")))
            {
                return true;
            }

            return false;
        }
    }
}
