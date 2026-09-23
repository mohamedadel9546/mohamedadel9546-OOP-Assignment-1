using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OredrLine
    {
     
        public Product Product { get; private set; } = null!;
        public int Quinty { get; private set; } 
        public OredrLine(Product product, int quinty)
        {
            Product = product;
            Quinty = quinty;
        }

        public double TotalLine => Product.Price * Quinty;

    }
}
