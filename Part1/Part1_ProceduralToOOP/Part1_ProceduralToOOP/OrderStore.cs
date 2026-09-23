using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderStore
    {
        private List<Customer> _customers = [];
        private List<Product> _Product = [];
        private List<Order> _order = [];

        public  IReadOnlyList<Customer> Customer => _customers;
        public IReadOnlyList<Product> Product => _Product;
        public IReadOnlyList<Order> Order => _order;

        public bool AddCustomer(Customer Customer)
        {
            if (_customers.Any(c => c.Id == Customer.Id)) return false;
            _customers.Add(Customer);
            return true;
        }
        public bool AddProduct(Product Product)
        {
            if (_Product.Any(c => c.Id == Product.Id)) return false;
            _Product.Add(Product);
            return true;
        }

        public Customer? FindCustomerById(int id) => _customers.FirstOrDefault(c=>c.Id== id);
        public Product? FindProductById(int id) => _Product.FirstOrDefault(c=>c.Id== id);
        public Order? FindorderById(int id) => _order.FirstOrDefault(c=>c.Id == id);
        public Order? CreateOrder(int OredrId,int customerId,string Date)
        {
            if (FindorderById(OredrId) != null) return null ;

            var customer = FindCustomerById(customerId);
            if (customer == null) return null;
            var order = new Order(OredrId, customer, Date);
            _order.Add(order);
            return order;
        }

        public double CalculateTotalOrders()
        {
            double Total = 0;
            foreach(var item in _order)
            {
                if (item.IsPaid)
                {
                    Total += item.CalculateTotal();
                }
            }
            return Total;
        }

    
             
    }
}
