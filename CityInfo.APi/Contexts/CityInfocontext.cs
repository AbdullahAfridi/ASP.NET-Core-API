using CityInfo.APi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Contexts
{
    public class CityInfocontext : DbContext
    {
     

        public DbSet<City> City {get;set;}
        public DbSet<PointOfInterest> PointOfInterests { get; set; }
        public CityInfocontext(DbContextOptions<CityInfocontext> options) : base(options)
        {

            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                new City()
                {
                    ID = 1,
                    Name= " Colombo",
                    Description = " Capital of Sri Lanka and Business city"

                },
                new City()
                {
                    ID = 2,
                    Name = " Negambo ",
                    Description = " Famous For Beautiful Beaches"
                },
                  new City()
                  {
                      ID = 3,
                      Name = " NuwaraEliya ",
                      Description = " The most beautiful part of Sri Lanka with beautiful climate"
                  },
                    new City()
                    {
                        ID = 4,
                        Name = " Badulla ",
                        Description = " The Most Developing City Of Sri Lanka"
                    });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest { 
                
                ID = 1,
                CityId =1,
                Name= " Galle Face",
                Description =" A beautiful beach and picnic spot in the center of colombo"
                
                },

                 new PointOfInterest
                 {

                     ID = 2,
                     CityId = 1,
                     Name = " Mount Lavina",
                     Description = " A beautiful place for beach lovers"

                 },

                  new PointOfInterest
                  {

                      ID = 3,
                      CityId = 2,
                      Name = " Spatty Moty",
                      Description = " Foregin Tourist Attraction Point"

                  },

                   new PointOfInterest
                   {

                       ID = 4,
                       CityId = 3,
                       Name = " Goergia Park",
                       Description = " A beautiful park in NuwaraEliya"

                   },

                    new PointOfInterest
                    {

                        ID = 5,
                        CityId = 4,
                        Name = " Uva Wellassa",
                        Description = " A beautiful university of Sri Lanka "

                    }



                );


            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   {
        // base.OnConfiguring(optionsBuilder);
        // }
    }
}
