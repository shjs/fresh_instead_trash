using System;
namespace mvc.Models.viewmodel
{
    public class Login
    {
        public string UsernameOrEMail { get; set; }
        public string Password { get; set; }


        public Login() : this("", "") { }
        public Login(string usernameOrEMail, string pwd)
        {
            this.UsernameOrEMail = usernameOrEMail;
            this.Password = pwd;
        }
    }
}
