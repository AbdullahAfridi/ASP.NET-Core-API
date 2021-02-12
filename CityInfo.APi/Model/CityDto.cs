using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Model
{
    public class CityDto
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
     


        public ICollection<PointOfInterestDto> PointOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
