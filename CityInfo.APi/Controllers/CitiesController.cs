using AutoMapper;
using CityInfo.APi.Model;
using CityInfo.APi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository cityInfo;
        private readonly IMapper mapper;

        public CitiesController(ICityInfoRepository cityInfo , IMapper mapper) {
            this.cityInfo = cityInfo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities() {

            var cityEntities = cityInfo.Getcities();
            /*var result = new List<CitywithoutPointOfInterestDto>();

            foreach (var cityEntity in cityEntities) {

                result.Add(new CitywithoutPointOfInterestDto { 
                
                ID = cityEntity.ID,
                Description = cityEntity.Description,
                Name = cityEntity.Name
                
                });   */
            
            
           // }

            return Ok(mapper.Map<IEnumerable<CitywithoutPointOfInterestDto>>(cityEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointOfInterest = false)
        {

            var city = cityInfo.GetCity(id, includePointOfInterest);

            if (city == null)
            {


                return NotFound();
            }

            if (includePointOfInterest)
            {



                return Ok (mapper.Map<CityDto>(city)); 
            }

          
            return Ok(mapper.Map<CitywithoutPointOfInterestDto>(city));
        }
    }
}
