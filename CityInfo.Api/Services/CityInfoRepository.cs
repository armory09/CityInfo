using System;
using System.Collections.Generic;
using System.Linq;
using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public bool CityExits(int cityId)
        {
            return _context.Cities.Any(x => x.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(x => x.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return _context.Cities.Include(x => x.PointsOfInterest)
                    .Where(x => x.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(x => x.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfinterestId)
        {
            return _context.PointsOfInterest
                .Where(x => x.CityId == cityId && x.Id == pointOfinterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
                .Where(x => x.CityId == cityId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
