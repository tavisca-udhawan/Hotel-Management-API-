using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management_System.Models
{
    public class EventStatus
    {
        public int code { get; set; }
      public string message { get; set; }
        public Status response  {get; set; }
 }

        public enum Status
        {
            Success,
            Failure,
            Warning
        }
}