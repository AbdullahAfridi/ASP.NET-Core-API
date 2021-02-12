using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() {

            CreateMap<Entities.City, Model.CitywithoutPointOfInterestDto>();
            CreateMap<Entities.City, Model.CityDto>();
            CreateMap<Entities.PointOfInterest, Model.PointOfInterestDto>();
            CreateMap<Model.PointOfInterestForCreationDto, Entities.PointOfInterest>();
            CreateMap<Model.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
        
        }
    }
}
