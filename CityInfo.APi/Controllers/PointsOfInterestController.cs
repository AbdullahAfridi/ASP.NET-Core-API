using AutoMapper;
using CityInfo.APi.Entities;
using CityInfo.APi.Model;
using CityInfo.APi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> logger;
        private readonly IMailService localMail;
        private readonly ICityInfoRepository cityInfo;
        private readonly IMapper mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,IMailService localMail, ICityInfoRepository cityInfo, IMapper mapper) {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.localMail = localMail?? throw new ArgumentNullException(nameof(localMail));
            this.cityInfo = cityInfo;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            if (!cityInfo.CityExists(cityId)) {

                return NotFound();
            
            }
            var poi = cityInfo.GetPointOfInterestForCity(cityId);
          

            return Ok(mapper.Map<IEnumerable<PointOfInterestDto>>(poi));

        }
        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {

            if (!cityInfo.CityExists(cityId))
            {

                return NotFound();

            }

            var cityP = cityInfo.GetPointOfInterestForCity(cityId, id);

          


            return Ok(mapper.Map<PointOfInterestDto>(cityP));
        }
        [HttpPost]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {

            if (pointOfInterest.Description == pointOfInterest.Name)
            {

                ModelState.AddModelError(
                    "Description",
                    "The Provide Description Must be different than the Name Lolz"
                    );
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            if (!cityInfo.CityExists(cityId)) {
                return NotFound();
            
            }


            var finalPointOfInterest = mapper.Map <PointOfInterest>(pointOfInterest);


            cityInfo.AddPointOfInterestForCity(cityId, finalPointOfInterest);
            cityInfo.save();
            var createdPointOfInterestToReturn = mapper.Map<PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute(
                "GetPointOfInterest", new { cityId, id = createdPointOfInterestToReturn.ID },
                 createdPointOfInterestToReturn
                );



        }
        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,

            [FromBody] PointOfInterestForUpdateDto pointOfInterest
            )
        {
            if (pointOfInterest.Description == pointOfInterest.Name)
            {

                ModelState.AddModelError(
                    "Description",
                    "The Provide Description Must be different than the Name Lolz"
                    );
            }
            if (!cityInfo.CityExists(cityId)) {

                return NotFound();
            }
            var pointOfInterestentity = cityInfo.GetPointOfInterestForCity(cityId, id);
            if (pointOfInterest == null) {

                return NotFound();
            }


            var pointOfInterestFromStor = cityInfo
                .GetPointOfInterestForCity(cityId, id);
            if (pointOfInterest == null)
            {

                return NotFound();
            }mapper.Map(pointOfInterest, pointOfInterestentity);

            cityInfo.save();
                return NoContent();
            
        }
        [HttpPatch("{id}")]

        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,

            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc
            ) {


            var city = CitiesDataStore.Current.Cities.FirstOrDefault(o => o.ID == cityId);

            if (city == null)
            {

                return NotFound();
            }
            var pointOfInterestFromStor = city.PointOfInterest
                .FirstOrDefault(p => p.ID == id);
            if (pointOfInterestFromStor  == null)
            {

                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {


                Name = pointOfInterestFromStor.Name,
                Description = pointOfInterestFromStor.Description
            };

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid) {

                return BadRequest(ModelState);
            }

            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {

                ModelState.AddModelError(
                    "Description",
                    "The Provide Description Must be different than the Name Lolz"
                    );

            }
            if (!TryValidateModel(pointOfInterestToPatch)) {

                return BadRequest(ModelState);
            }

            pointOfInterestFromStor.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStor.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult DeletePointOfInterest(int cityId, int id) {

            if (!cityInfo.CityExists(cityId)) {

                return NotFound();
            }
            var pointOfInterestEntity = cityInfo
               .GetPointOfInterestForCity(cityId, id);
            if (pointOfInterestEntity == null)
            {

                return NotFound();
            }


            cityInfo.DeletePointOfInterest(pointOfInterestEntity);
            cityInfo.save();

            localMail.Send("Point of interest deleted.",
                    $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Description} was deleted.");

            return NoContent();
        }
    }
}
