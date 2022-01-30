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
                    new Car { Id = 1, Make = "Make1", Model = "Model1", YearModel = 2005, Price = 10000M, Licensed = false, DateAdded = new DateTime(2022, 01, 01), WarehouseId = 1 },
                    new Car { Id = 2, Make = "Make2", Model = "Model2", YearModel = 1998, Price = 500M, Licensed = false, DateAdded = new DateTime(2020, 01, 01), WarehouseId = 1 },
                    new Car { Id = 3, Make = "Make3", Model = "Model3", YearModel = 2010, Price = 300000M, Licensed = false, DateAdded = new DateTime(2021, 01, 01), WarehouseId = 2 },
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
                var warehouseService = new WarehouseService(context);
                var carService = new CarService(context, mapper, warehouseService);
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
                    new Car { Id = 2, Make = "Make2", Model = "Model2", YearModel = 1998, Price = 500M, Licensed = false, DateAdded = new DateTime(2020, 01, 01), WarehouseId = 1 },
                    new Car { Id = 3, Make = "Make3", Model = "Model3", YearModel = 2010, Price = 300000M, Licensed = false, DateAdded = new DateTime(2021, 01, 01), WarehouseId = 1 },
                    new Car { Id = 1, Make = "Make1", Model = "Model1", YearModel = 2005, Price = 10000M, Licensed = false, DateAdded = new DateTime(2022, 01, 01), WarehouseId = 1 },
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
                var warehouseService = new WarehouseService(context);
                var carService = new CarService(context, mapper, warehouseService);
                var getAll = await carService.GetAllBasic();
                actualList = getAll.ToList();
            }

            // Assert
            Assert.Equal(expectedList[0].Id, actualList[0].Id);
            Assert.Equal(expectedList[1].Id, actualList[1].Id);
            Assert.Equal(expectedList[2].Id, actualList[2].Id);


        }

        [Fact]
        public async void GetDetails_ShouldReturnCorrectCar()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ShouldHaveSortedCars")
                .Options;
            var myProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            var falseWarehouse = new Warehouse { Id = 1, Name = "Warehouse", Longitude = 11, Latitude = 222 };
            using (var context = new DataContext(options))
            {
                context.Add(falseWarehouse);
                context.SaveChanges();

                foreach (var car in _cars)
                {
                    context.Add(car);
                    context.SaveChanges();
                }
            }
            
            var expectedCar = new CarDetailedModel { Id = 1, Make = "Make1", Model = "Model1", YearModel = 2005, Price = 10000M, Licensed = false, WarehouseName = falseWarehouse.Name, WarehouseLatitude = falseWarehouse.Latitude, WarehouseLongitude = falseWarehouse.Longitude };

           // Act
           CarDetailedModel actualCar;
            using (var context = new DataContext(options))
            {
                    var warehouseService = new WarehouseService(context);
                    var carService = new CarService(context, mapper, warehouseService);
                    var getDetails = await carService.GetDetails(expectedCar.Id);
                    actualCar = getDetails;
            }


            // Assert
            Assert.Equal(expectedCar.Id, actualCar.Id);
            Assert.Equal(expectedCar.Make, actualCar.Make);
            Assert.Equal(expectedCar.Price, actualCar.Price);
            Assert.Equal(expectedCar.WarehouseName, actualCar.WarehouseName);
            Assert.Equal(expectedCar.WarehouseLongitude, actualCar.WarehouseLongitude);
            Assert.Equal(expectedCar.WarehouseLatitude, actualCar.WarehouseLatitude);
        }
    }
}
