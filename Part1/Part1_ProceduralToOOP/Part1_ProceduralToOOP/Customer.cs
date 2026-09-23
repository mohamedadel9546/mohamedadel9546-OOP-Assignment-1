using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; } 
        public string Email { get; private set; } 
        public string City { get; private set; } 
        public bool IsVip { get; private set; } 

        public Customer(int id, string name, string email, string city, bool isVip)
        {
            if (id <= 0) throw new ArgumentException();
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(city))
            {
                throw new ArgumentException();
            }
                
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }
    }
}
