using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CorePractice.Models
{
    public class Group
    {
        [Required]
        public int GroupId { get; set; }

        [MaxLength(50)]
        [Required]
        public string GroupName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public List<User> Users { get; set; }
    }
}