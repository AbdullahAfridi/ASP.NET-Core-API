using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Model
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore() {

            Cities = new List<CityDto>() {

        new CityDto(){

         ID=1,
         Name= " Colombo",
         Description=" The Capital Of Sri Lanka",
         PointOfInterest = new List<PointOfInterestDto>(){ 
         
         new PointOfInterestDto(){
         
         ID =2,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         },
          new PointOfInterestDto(){

         ID =9,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         }


         


         }
        
        },
          new CityDto(){

         ID=2,
         Name= " Negambo",
         Description=" Famous for beaches",
          PointOfInterest = new List<PointOfInterestDto>(){

         new PointOfInterestDto(){

         ID =4,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         }


         }

        },
            new CityDto(){

         ID=3,
         Name= " Kandy",
         Description=" Center of Sri Lanka",
          PointOfInterest = new List<PointOfInterestDto>(){

         new PointOfInterestDto(){

         ID =4,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         }


         }

        },
              new CityDto(){

         ID=4,
         Name= " Badulla",
         Description=" Has Great Weather",
          PointOfInterest = new List<PointOfInterestDto>(){

         new PointOfInterestDto(){

         ID =5,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         }


         }

        },
                new CityDto(){

         ID=5,
         Name= " Nuwara Eliya",
         Description=" The Beautiy  Of Sri Lanka",
          PointOfInterest = new List<PointOfInterestDto>(){

         new PointOfInterestDto(){

         ID =6,
         Name=" Cathedral Of Your aldy",
         Description=" A great place for histotians to visit"
         }


         }

        },
          new CityDto(){

         ID=6,
         Name= " Batticola",
         Description=" Muslim Majority Place Of Sri Lanka",
          PointOfInterest = new List<PointOfInterestDto>(){

         new PointOfInterestDto(){

         ID =7,
         Name=" Cathedral Of Your lady",
         Description=" A great place for histotians to visit"
         }


         }

        },



        };
        }
    }


}
