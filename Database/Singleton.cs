using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database
{
    public class Singleton : IDatabase
    {
        private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        private Singleton() { }

        //TODO: add collections for items in the exercise
        private readonly List<User> _users = [];
        private readonly List<Equipment> _equipments= [];
        private readonly List<Rental> _rentals= [];

        public void SaveUser(User user)
        {
            _users.Add(user);
        }

        public void SaveEquipment(Equipment equipment)
        {   
            _equipments.Add(equipment);
        }

        public List<Equipment> GetAllEquipment()
        {
            return _equipments;
        }

        public void SaveRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public List<Rental> GetAllRentals()
        {
            return _rentals;
        }
    }
}
