using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public List<Group> Groups { get; set; }

        public User(int UserId, 
                    string Username, 
                    string Password, 
                    string Firstname, 
                    string Lastname, 
                    DateTime DateOfBirth,
                    string Email,
                    string Phone,
                    string Mobile
                    )
        {
            this.UserId = UserId;
            this.Username = Username;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.Email = Email;
            this.Phone = Phone;
            this.Mobile = Mobile;
            this.Groups = new List<Group>();
        }
    }
}