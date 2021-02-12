using CityInfo.APi.Contexts;
using CityInfo.APi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfocontext context;

        public CityInfoRepository(CityInfocontext context)
        {
            this.context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointOfInterest.Add(pointOfInterest);

        }

        public bool CityExists(int cityId)
        {
            return context.City.Any(c => c.ID == cityId);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            context.PointOfInterests.Remove(pointOfInterest);
        }

        public IEnumerable<City> Getcities()
        {
            return context.City.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointOfInterest)
        {

            if (includePointOfInterest) {

                return context.City.Include(c => c.PointOfInterest).Where(c => c.ID == cityId).FirstOrDefault();
            }
            return context.City.Where(o => o.ID == cityId ).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointOfInterestForCity(int cityId)
        {
            return context.PointOfInterests.Where(o => o.CityId == cityId).ToList();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return context.PointOfInterests.Where(o => o.CityId == cityId && o.ID == pointOfInterestId).FirstOrDefault();
        }

        public bool save()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
