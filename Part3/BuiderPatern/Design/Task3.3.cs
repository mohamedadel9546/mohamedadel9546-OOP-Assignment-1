using System;
using System.Collections.Generic;
using System.Text;

namespace Design;

public class Adress
{
    public string Street { get;private set; } = null!;
    public string City { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string? State { get; private set; }
    public string? ZipCode { get; private set; }
    public Adress(string street, string city, string country, string? state, string? zipCode)
    {
        Street = street;
        City = city;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }
}


public class AddressBuilder
{
    public string Street { get;  } = null!;
    public string City { get; } = null!;
    public string Country { get; } = null!;
    public string? State { get; private set; }
    public string? ZipCode { get;private set; }
    public AddressBuilder(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
    public AddressBuilder WithState(string state)
    {
        State = state;
        return this;
    }
    public AddressBuilder WithZipCode(string zipcode)
    {
        ZipCode = zipcode;
        return this;
    }
    public Adress Build()
    {
        return new Adress(Street, City, Country, State, ZipCode);
    }
}  


public class Order
{
    public string Date { get; set; } = null!;
    public string Currancy { get; set; } = null!;
    public decimal Suptotal { get;private set; } 
    public decimal DiscountAmount { get;private set; } 
    public decimal Taxamount { get; private set; }
    public decimal TotalAmount => Suptotal + Taxamount - DiscountAmount;
    public Order(string date, string currancy, decimal suptotal, decimal discountamount,decimal taxamount)
    {
        Date = date;
        Currancy = currancy;
        Suptotal = suptotal;
        DiscountAmount = discountamount;
        Taxamount = taxamount;
    }
}
public class OredrBuilder
{
    private string Date { get; set; } = null!;
    private string Currancy { get; set; } = null!;
    private decimal Suptotal { get; set; }
    private decimal DiscountAmount { get; set; }
    private decimal Taxamount { get; set; }
    private decimal TotalAmount => Suptotal + Taxamount - DiscountAmount;
   public OredrBuilder(string date, string currancy, decimal suptotal)
    {
        Date = date;
        Currancy = currancy;
        Suptotal = suptotal;
    }

    public OredrBuilder WithDiscount(decimal amount)
    {
        DiscountAmount = amount;
        return this;
    }
    public OredrBuilder WithTaxamount(decimal taxamount)
    {
        Taxamount = taxamount;
        return this;
    }

    public Order Build() {
        return new Order(Date, Currancy, Suptotal, DiscountAmount, Taxamount);
     }
}


public class Invoice
{
  internal   Invoice(int invoiceId, string name, string? email, string? phone, Adress billingOrder,
        Adress shippingOrder, Order order)
    {
        InvoiceId = invoiceId;
        Name = name;
        Email = email;
        Phone = phone;
        BillingAddress = billingOrder;
        ShippingAddress = shippingOrder;
        Order = order;
    }

    public int InvoiceId { get;  }
    public string Name { get;  } = null!;
   public string? Email { get;  }
   public string? Phone { get;  }

    public Adress BillingAddress { get;  } = null!;
    public Adress ShippingAddress { get;  } = null!;
    public Order Order { get;  } = null!;
}
public class InvoiceBulider
{
    public InvoiceBulider(int invoiceId, string name, Adress billingOrder, Adress shippingOrder, Order order)
    {
        InvoiceId = invoiceId;
        Name = name;
        BillingAddress = billingOrder;
        ShippingAddress = shippingOrder;
        Order = order;
    }

    private int InvoiceId { get; set; }
    private string Name { get; set; } = null!;
    private Adress BillingAddress { get; set; } = null!;
    private Adress ShippingAddress { get; set; } = null!;
    private Order Order { get; set; } = null!;

    private string? Email { get; set; }
    private string? Phone { get; set; }
    
    public InvoiceBulider WithEmail(string email)
    {
        Email = email;
        return this;
    }
    public InvoiceBulider WithPhone(string phone)
    {
        Phone = phone;
        return this;
    }
 
    public Invoice Build()
    {
        return new Invoice(InvoiceId,Name,Email,Phone, BillingAddress, ShippingAddress, Order);
    }
}