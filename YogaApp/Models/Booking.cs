using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ClassInstanceId { get; set; }
        public string UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public YogaClassInstance ClassInstance { get; set; }
    }
}
