using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseApi.Data;
using WarehouseApi.Models;
using WarehouseApi.Services;
using Xunit;

namespace WarehouseApi.Tests.ServicesTests
{
    public class CarServiceTest
    {

        private List<Car> _cars = new List<Car>
                {
                    new Car { Id = 1, Make = "Make1", Model = "Model1", YearModel = 2005, Price = 10000M, Licensed = false, DateAdded = new DateTime(2022, 01, 01) },
                    new Car { Id = 2, Make = "Make2", Model = "Model2", YearModel = 1998, Price = 500M, Licensed = false, DateAdded = new DateTime(2020, 01, 01) },
                    new Car { Id = 3, Make = "Make3", Model = "Model3", YearModel = 2010, Price = 300000M, Licensed = false, DateAdded = new DateTime(2021, 01, 01) },
                };

        [Fact]
        public async void GetAll_ShouldGetAllCars()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ShouldGetAllGames")
                .Options;
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            List<Car> expectedList = _cars;


            using (var context = new DataContext(options))
            {
                foreach (var car in _cars)
                {
                    context.Add(car);
                    context.SaveChanges();
                }
            }


            // Act
            List<CarBasicModel> actualList;
            using (var context = new DataContext(options))
            {
                var carService = new CarService(context, mapper);
                var getAll = await carService.GetAllBasic();
                actualList = getAll.ToList();
            }

            // Assert
            Assert.Equal(expectedList.Count(), actualList.Count());
        }

        [Fact]
        public async void GetAll_ShouldBeSortedByDate()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ShouldHaveSortedCars")
                .Options;
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            List<Car> expectedList = new List<Car>
                {
                    new Car { Id = 2, Make = "Make2", Model = "Model2", YearModel = 1998, Price = 500M, Licensed = false, DateAdded = new DateTime(2020, 01, 01) },
                    new Car { Id = 3, Make = "Make3", Model = "Model3", YearModel = 2010, Price = 300000M, Licensed = false, DateAdded = new DateTime(2021, 01, 01) },
                    new Car { Id = 1, Make = "Make1", Model = "Model1", YearModel = 2005, Price = 10000M, Licensed = false, DateAdded = new DateTime(2022, 01, 01) },
                };

            using (var context = new DataContext(options))
            {
                foreach (var car in _cars)
                {
                    context.Add(car);
                    context.SaveChanges();
                }
            }

            // Act
            List<CarBasicModel> actualList;
            using (var context = new DataContext(options))
            {
                var carService = new CarService(context, mapper);
                var getAll = await carService.GetAllBasic();
                actualList = getAll.ToList();
            }

            // Assert
            Assert.Equal(expectedList[0].Id, actualList[0].Id);
            Assert.Equal(expectedList[1].Id, actualList[1].Id);
            Assert.Equal(expectedList[2].Id, actualList[2].Id);


        }
    }
}
