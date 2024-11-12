using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApp.Models
{
    public class ClassDetails
    {
        public YogaClass YogaClass { get; set; }
        public YogaClassInstance Instance { get; set; }
        public int AvailableSpots { get; set; }
        public bool IsBookable => AvailableSpots > 0;
        public List<string> Equipment { get; set; }
        public string LocationDetails { get; set; }
        public string CancellationPolicy { get; set; }
    }
}
