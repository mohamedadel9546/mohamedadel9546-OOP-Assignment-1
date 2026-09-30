using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        public int Id { get;private set; }
        public Customer Customer { get; private set; } = null!;
        public string Date { get; private set; }
        public bool IsPaid { get; private set; }

        private List<OredrLine> _oredrline = [];
        public IReadOnlyList<OredrLine> Orderline => _oredrline;
        public Order(int id, Customer customer, string date)
        {
            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public bool AddLine(Product? product,int quinty)
        {
            if (IsPaid) return false;

            if (product is null) return false;
            
          if (!product.ReduceStock(quinty)) return false;

            var item = new OredrLine(product, quinty);
            _oredrline.Add(item);
            return true;
        }

           
        public bool MarkPaid()
        {
            if (_oredrline.Count == 0) return false;
            IsPaid = true;
            return true;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach(var item in _oredrline)
            {
                total += item.TotalLine;
            }

            if (Customer.IsVip) total=total * 0.9;
            return total;

        }

            
    }
}
