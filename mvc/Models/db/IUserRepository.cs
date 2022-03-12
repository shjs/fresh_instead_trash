using System;
using System.Collections.Generic;
using mvc.Models.viewmodel;

namespace mvc.Models.db.sql
{
    public interface IUserRepository
    {
        void Open();
        void Close();
        User Authenticate(string EmailAddress, string password);
        User GetUser(int id);
        List<User> GetAllUsers();
        bool DeleteUser(int userToDelete);

    }
}
