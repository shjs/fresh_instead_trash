using System;
namespace mvc.Models.viewmodel
{
    public enum Gender {
        male, female, notSpecified
    }
    public class User {
        public int? UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public string Username { get; set; }
        public Boolean IsAdmin { get; set; }

        public User() : this(null, "","",0, null, null, "","","", false) { }
        public User(int? userId, string firstname, string lastname, int age, Gender? gender, DateTime? birthdate, 
            string email, string passwrd, string username, Boolean IsAdmin)
        {
            this.UserId = userId;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Gender = gender;
            this.Birthdate = birthdate;
            this.Email = email;
            this.Password = passwrd;
            this.Username = username;
            this.IsAdmin = IsAdmin;
        }
    }
}