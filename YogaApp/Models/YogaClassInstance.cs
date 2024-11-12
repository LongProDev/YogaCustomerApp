using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApp.Models
{
    public class YogaClassInstance
    {
        public int Id { get; set; }
        public int YogaClassId { get; set; }
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public string Comments { get; set; }
    }
}
