using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
   public class ShowBookings
    {
        public int ShowID { get; set; }
        public string ChooseCity { get; set; }
        public string ChooseCabType { get; set; }
        public string PickUpLocality { get; set; }
        public string DropLocality { get; set; }
        public DateTime PickUPDate { get; set; }
        public DateTime PickUpTime { get; set; }
        public string TypeName { get; set; }
        public string TravellerName { get; set; }
        public string TravellerPhone { get; set; }
        public string StatusAdmin { get; set; }
    }
}
