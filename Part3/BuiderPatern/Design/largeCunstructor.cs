using System;
using System.Collections.Generic;
using System.Text;

namespace Design;

public class LargeCunstructor
{


    //Mandotry
    //Customer
    private int InvoiceId { get; set; }
    private string CustomerName { get; set; } = null!;
    //Billing
    private string BillingStreet { get; set; } = null!;
    private string BillingCity { get; set; } = null!;
    private string BillingCountry { get; set; } = null!;
    //Shiping
    private string ShippingStreet { get; set; } = null!;
    private string ShippingCity { get; set; } = null!;
    private string ShippingCountry { get; set; } = null!;
    //Oredr
    private string OrderDate { get; set; } = null!;
    private string Currency { get; set; } = null!;
    private decimal SubTotal { get; set; }
    //Optianla
    //Customer
    private string? CustomerEmail { get; set; }
    private string? CustomerPhone { get; set; }
    //Billing
    private string? BillingState { get; set; } = null!;
    private string? BillingZipCode { get; set; } = null!;

    //Shiping
    private string? ShippingState { get; set; }
    private string? ShippingZipCode { get; set; }
    //Oredr
    private decimal DiscountAmount { get; set; }
    private decimal TaxAmount { get; set; }
    private decimal TotalAmount => SubTotal + TaxAmount - DiscountAmount;

    public LargeCunstructor(int invoiceId, string customerName, string? customerEmail, string? customerPhone
        , string billingStreet, string billingCity, string? billingState, string? billingZipCode
        , string billingCountry, string shippingStreet, string shippingCity, string? shippingState,
        string? shippingZipCode, string shippingCountry, string orderDate, string currency, decimal subTotal,
        decimal discountAmount, decimal taxAmount)
    {
        InvoiceId = invoiceId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        BillingStreet = billingStreet;
        BillingCity = billingCity;
        BillingState = billingState;
        BillingZipCode = billingZipCode;
        BillingCountry = billingCountry;
        ShippingStreet = shippingStreet;
        ShippingCity = shippingCity;
        ShippingState = shippingState;
        ShippingZipCode = shippingZipCode;
        ShippingCountry = shippingCountry;
        OrderDate = orderDate;
        Currency = currency;
        SubTotal = subTotal;
        DiscountAmount = discountAmount;
        TaxAmount = taxAmount;
    }

}

public class LargeCunstructorBuilder
{
    public LargeCunstructorBuilder(int invoiceId, string customerName, string billingStreet, string billingCity,
        string billingCountry, string shippingStreet, string shippingCity, string shippingCountry, string orderDate,
        string currency, decimal subTotal)
    {
        InvoiceId = invoiceId;
        CustomerName = customerName;
        BillingStreet = billingStreet;
        BillingCity = billingCity;
        BillingCountry = billingCountry;
        ShippingStreet = shippingStreet;
        ShippingCity = shippingCity;
        ShippingCountry = shippingCountry;
        OrderDate = orderDate;
        Currency = currency;
        SubTotal = subTotal;
    }

//Mandotry
    //Customer
    private int InvoiceId { get; set; }
    private string CustomerName { get; set; } = null!;
  //Billing
    private string BillingStreet { get; set; } = null!;
    private string BillingCity { get; set; } = null!;
   private string BillingCountry { get; set; } = null!;
  //Shiping
     private string ShippingStreet { get; set; } = null!;
     private string ShippingCity { get; set; } = null!;
     private string ShippingCountry { get; set; } = null!;
 //Oredr
    private string OrderDate { get; set; } = null!;
    private string Currency { get; set; } = null!;
    private decimal SubTotal { get; set; }
//Optianla
    //Customer
    private string? CustomerEmail { get; set; }
    private string? CustomerPhone { get; set; } 
    //Billing
    private string? BillingState { get; set; } = null!;
    private string? BillingZipCode { get; set; } = null!;
    
    //Shiping
    private string? ShippingState { get; set; } 
    private string? ShippingZipCode { get; set; } 
    //Oredr
    private decimal DiscountAmount { get; set; }
    private decimal TaxAmount { get; set; }
    private decimal TotalAmount => SubTotal + TaxAmount - DiscountAmount;


    public LargeCunstructorBuilder EnterEmail(string email )
    {
        CustomerEmail = email;
        return this;
    }
    public LargeCunstructorBuilder EnterPhone(string phone )
    {
        CustomerPhone = phone;
        return this;
    }
    public LargeCunstructorBuilder EnterBillingState(string billingstate )
    {
        BillingState = billingstate;
        return this;
    }
    public LargeCunstructorBuilder EnterBillingZipCode(string ZipCode )
    {
        BillingZipCode = ZipCode;
        return this;
    }


    public LargeCunstructorBuilder EnterShippingState(string shippingstate)
    {
        ShippingState = shippingstate;
        return this;
    }
    public LargeCunstructorBuilder EnterShippingZipCode(string shippingzipcode)
    {
        ShippingZipCode = shippingzipcode;
        return this;
    }
    public LargeCunstructorBuilder EnterDiscountAmount(decimal discountamount)
    {
        DiscountAmount = discountamount;
        return this;
    }
    public LargeCunstructorBuilder EnterTaxAmount(decimal taxamount)
    {
        TaxAmount = taxamount;
        return this;
    }


    public LargeCunstructor Build()
    {
        return new LargeCunstructor(InvoiceId, CustomerName, CustomerEmail, CustomerPhone,
            BillingStreet, BillingCity, BillingState, BillingZipCode, BillingCountry, ShippingStreet, ShippingCity, ShippingState,
            ShippingZipCode, ShippingCountry, OrderDate, Currency, SubTotal, DiscountAmount, TaxAmount);
       
    }

}
