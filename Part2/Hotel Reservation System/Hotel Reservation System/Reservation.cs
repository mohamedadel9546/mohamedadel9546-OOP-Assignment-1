using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Hotel_Reservation_System
{
    public class Reservation
    {

        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public ReservationStatus RStatus { get; private set; }
        public Room Room { get;private set;}
        public decimal TotalPrice { 
            get{
                TimeSpan diff = CheckOutDate - CheckInDate;
                var total = diff.Days * Room.NightlyRate;
                return total;
              } 
        }

        public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate,
            Room room)
        {
            if (CheckOutDate < CheckInDate) throw new ArgumentException();
            if(room!.IsUnderMaintenance==true) throw new InvalidOperationException("Cannot create a reservation for a room currently under maintenance.");
            if (room is null) throw new ArgumentNullException(nameof(room));
            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            RStatus = ReservationStatus.Pending;
            Room = room;
        }

        public void Confirm()
        {
            if(RStatus != ReservationStatus.Pending)
                throw new InvalidOperationException($"Cannot confirm reservation from status: {RStatus}.");
            RStatus = ReservationStatus.Confirmed;
        }
        public void CheckIn()
        {
            if(RStatus != ReservationStatus.Confirmed)
                throw new InvalidOperationException($"Cannot CheckIn reservation from status: {RStatus}.");
            RStatus = ReservationStatus.CheckedIn;
        }
        public void CheckOut()
        {
            if(RStatus != ReservationStatus.CheckedIn)
                throw new InvalidOperationException($"Cannot CheckIn reservation from status: {RStatus}.");
            RStatus = ReservationStatus.CheckedOut;
        }
        public void Cancelled()
        {
            if(RStatus != ReservationStatus.CheckedOut)
                throw new InvalidOperationException($"Cannot CheckIn reservation from status: {RStatus}.");
            RStatus = ReservationStatus.Cancelled;
        }
        public void PrintInvoice(Guest guest)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("            HOTEL RESERVATION INVOICE      ");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Reservation ID : {ReservationId}");
            Console.WriteLine($"Status         : {RStatus}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("GUEST DETAILS:");
            Console.WriteLine($"Name           : {guest.FullName}");
            Console.WriteLine($"Phone          : {guest.PhoneNumber}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("ROOM DETAILS:");
            Console.WriteLine($"Room Number    : {Room.RoomNumber} ({Room.Roomtype})");
            Console.WriteLine($"Nightly Rate   : {Room.NightlyRate:C}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("STAY DETAILS:");
            Console.WriteLine($"Check-In       : {CheckInDate:yyyy-MM-dd}");
            Console.WriteLine($"Check-Out      : {CheckOutDate:yyyy-MM-dd}");
            Console.WriteLine($"Total Nights   : {(CheckOutDate - CheckInDate).Days}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"TOTAL AMOUNT   : {TotalPrice:C}");
            Console.WriteLine("==========================================");
        }
    }
}
