using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace user_dashboard.Models
{
    public class User : BaseEntity{
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string UserLevel {get; set;}
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}
    }
}