using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_System
{
    public class Room
    {
      
        public int RoomNumber { get; }
        public decimal NightlyRate { get; private set; }
        public Roomtype Roomtype { get; }
        public bool IsUnderMaintenance { get; private set; } = false;
        public Room(int roomNumber, decimal nightlyRate, Roomtype roomtype)
        {
            RoomNumber = roomNumber;
            NightlyRate = nightlyRate;
            Roomtype = roomtype;
            IsUnderMaintenance = false;
        }

        public void UnderMantainance() =>IsUnderMaintenance = true;
        public void EndMantainance() =>IsUnderMaintenance = false;



        public void ChangeNightlyRate(decimal NewRate) {
            if(NewRate<=0) throw new ArgumentOutOfRangeException(nameof(NewRate), "Nightly rate must be positive.");
            NightlyRate = NewRate;
        } 
            


    }
}
