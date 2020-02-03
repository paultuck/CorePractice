using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class User
    {
        int UserId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Mobile { get; set; }
        List<Group> Groups { get; set; }
    }
}