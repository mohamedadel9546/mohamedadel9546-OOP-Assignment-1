using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Hotel_Reservation_System;

public class Guest
{
    public int GuestId { get;}
    public string PhoneNumber { get;}
    public string FullName { get;}
    private readonly List<Reservation> _reservation = [];
    public IReadOnlyList<Reservation> Reservation => _reservation;

    public Guest(int guestId, string phoneNumber, string fullName)
    {
        if (guestId <= 0) throw new ArgumentException("Cannot guestId is negetive",nameof(guestId));
        if(string.IsNullOrEmpty(fullName)) throw new ArgumentException();
        if(string.IsNullOrEmpty(phoneNumber)) throw new ArgumentException();
        GuestId = guestId;
        PhoneNumber = phoneNumber;
        FullName = fullName;
    }

    public Reservation MakeResrevation(int reservationId, DateTime checkInDate, DateTime checkOutDate ,Room room)
       
    {
        var NewRes = new Reservation(reservationId, checkInDate, checkOutDate, room);

        bool IsOverlaping = _reservation.Any(r=>
         r.Room.RoomNumber== room.RoomNumber&&
         r.RStatus!=ReservationStatus.Cancelled&&
         r.RStatus != ReservationStatus.CheckedOut&&
         checkInDate<r.CheckOutDate&&
         checkOutDate>r.CheckInDate);

        if (IsOverlaping)
        {
            throw new InvalidOperationException($"Room {room.RoomNumber} is already booked for the selected dates.");
        }
        _reservation.Add(NewRes);
        return NewRes;
    }
}
