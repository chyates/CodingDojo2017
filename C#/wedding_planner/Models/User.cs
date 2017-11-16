using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace wedding_planner.Models
{
    public class User : BaseEntity {
    public int UserId {get;set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public List<Guest> Weddings {get; set;}
    public DateTime Created_At {get;set;}
    public DateTime Updated_At {get;set;}

    public User()
    {
        Weddings = new List<Guest>();
    }
    }
}