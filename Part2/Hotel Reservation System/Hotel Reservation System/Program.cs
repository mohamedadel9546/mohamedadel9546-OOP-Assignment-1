
namespace Hotel_Reservation_System
{ 
   public enum Roomtype
        {
            Single,
            Double,
            Suite
        }
    public enum ReservationStatus
        {
            Pending, 
            Confirmed,
            CheckedIn,
            CheckedOut,
            Cancelled
        }
    internal class Program
    {
       
        static void Main(string[] args)
        {

            var room = new Room(1, 20, Roomtype.Single);
            var guest = new Guest(1, "01234556655", "Gaser");
            var res = guest.MakeResrevation(1, new DateTime(2026,09,22), new DateTime(2026,09,25), room);

            res.PrintInvoice(guest);


        }
    }
}
