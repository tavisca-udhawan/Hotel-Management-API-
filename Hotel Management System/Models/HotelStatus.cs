using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management_System.Models
{
    public class HotelStatus
    {
        public List<HotelDetails> Hotels { get; set; }
      
        public EventStatus Status { get; set; }
    }

}