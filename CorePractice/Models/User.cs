using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CorePractice.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(128)]
        [Required]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required]
        public string Firstname { get; set; }

        [MaxLength(100)]
        [Required]
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(256)]
        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(50)]
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