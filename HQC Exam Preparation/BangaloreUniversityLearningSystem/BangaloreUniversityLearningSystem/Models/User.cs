namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using Enums;
    using Utilities;

    public class User
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Password = password;
            this.Username = username;           
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    string message = string.Format("The password must be at least 5 symbols long.");
                    throw new ArgumentException(message);
                }

                if (value.Length < 6)
                {
                    string message = string.Format("The password must be at least 6 symbols long.");
                    throw new ArgumentException(message);
                }

                string hashPassword = HashUtilities.HashPassword(value);
                this.passwordHash = hashPassword;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    string message = string.Format("The username must be at least 5 symbols long.");
                    throw new ArgumentException(message);
                }

                if (value.Length < 5)
                {
                    string message = string.Format("The username must be at least 5 symbols long.");
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }
    }
}
