using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }


        public bool ReduceStock(int quinty)
        {
            if (quinty <= 0 || quinty > Stock)
                return false;

            if (quinty > Stock)
                Stock -= quinty;
                return true;      
        }

    }
}
