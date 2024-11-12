using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApp.Models
{
    public class YogaClass
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public int Capacity { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
