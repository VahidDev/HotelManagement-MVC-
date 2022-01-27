using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;

namespace Hotel.Utilities.ControllerUtilities
{
    public static class DateChecker
    {
        public static bool IsValid(DateTime startDate,DateTime endDate)
        {
            if (startDate < endDate) return true;
            return false;
        }
        public static bool IsConflicted(Room room, DateTime startDate, DateTime endDate)
        {
            //1) Check if the chosen startDate is equal to either start or end date
            // of one of the reservations of this room
            //2) Check if the chosen EndDate is equal to either start or end date
            // of one of the reservations of this room
            //3) Check if the chosen range's startDate is in
            //the middle of database's room reservation 
            //4)Check if the chosen range's endDate is in the middle of database's room reservation
            //5) Check if the range of database room reservation is in the middle of the chosen range
            //6)Check if the chosen range is in the middle of the database's room reservation range

            if (room.Reservations.Any(res =>
               (res.StartDate == startDate || startDate == res.EndDate) ||
               (res.StartDate == endDate || endDate == res.EndDate) ||
               (res.StartDate < startDate && startDate < res.EndDate) ||
               (res.StartDate < endDate && endDate < res.EndDate) ||
               (res.StartDate > startDate && endDate > res.EndDate) ||
               (res.StartDate < startDate && endDate < res.EndDate)
              )) return true;
           
            return false;
        }
    }
}
