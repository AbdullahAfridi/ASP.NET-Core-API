using CityInfo.APi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> Getcities();
        City GetCity(int cityId, bool includePointOfInterest);

        IEnumerable<PointOfInterest> GetPointOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
         bool CityExists(int cityId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        bool save();
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
    }
}
