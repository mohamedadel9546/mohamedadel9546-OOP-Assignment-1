namespace Design
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //var lr = new LargeCunstructorBuilder(1,"Gaser","bahr","mansoura","Bahr","MANSOURA","Bahr","Egypt","2026-09-23",
            //    "Dolar",1000)
            //    .EnterDiscountAmount(20)
            //    .EnterPhone("01270582569")
            //    .EnterShippingZipCode("A123")
            //    .Build();

            var Billing = new AddressBuilder("BAHR","MANSOURA","EGYPT").Build();
            var SHIPING = new AddressBuilder("ROMANA","BORSAID","EGYPT").Build();
            var OREDR = new OredrBuilder("2026-09-23","DOLAR",2000).WithDiscount(50).Build();
            var INVOICE = new InvoiceBulider(1,"GASER", Billing, SHIPING, OREDR).Build();

            Console.WriteLine(INVOICE.ShippingAddress.City);
        }
    }
}
