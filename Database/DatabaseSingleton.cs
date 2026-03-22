using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database
{
    public class DatabaseSingleton : IDatabase
    {
        private static DatabaseSingleton? _instance;

        public static DatabaseSingleton Instance
        {
            get
            {
                _instance ??= new DatabaseSingleton();
                return _instance;
            }
        }

        private DatabaseSingleton() { }

        //TODO: add collections for items in the exercise
        private readonly List<User> _users = [];

        public void SaveUser(User user)
        {
            _users.Add(user);
        }
    }
}
