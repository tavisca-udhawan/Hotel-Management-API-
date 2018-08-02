using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management_System.Models
{
    public class HotelDetails
    {
        public int ID { get; set; }

        public string  Name { get; set; }
        public int AvailableRooms { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }

        
    }
}