using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApi.Data;
using WarehouseApi.Models;
using WarehouseApi.Services;
using Xunit;

namespace WarehouseApi.Tests.ServicesTests
{
    public class WarehouseServiceTest
    {
        private List<Warehouse> _warehouses = new List<Warehouse>
        {
            new Warehouse { Id = 1, Name = "Test1", Latitude = 11, Longitude = 1111},
            new Warehouse { Id = 2, Name = "Test2", Latitude = 22, Longitude = 2222}
        };

        [Fact]
        public async void GetById_ShouldGetCorrectWarehouse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ShouldGetAllGames")
                .Options;

            var expected = new Warehouse { Id = 1, Name = "Test1", Latitude = 11, Longitude = 1111 };


            using (var context = new DataContext(options))
            {
                foreach (var warehouse in _warehouses)
                {
                    context.Add(warehouse);
                    context.SaveChanges();
                }
            }

            // Act
            Warehouse actual;
            using (var context = new DataContext(options))
            {
                var warehouseService = new WarehouseService(context);
                actual = await warehouseService.GetById(expected.Id);
            }

            // Assert
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Latitude, actual.Latitude);
            Assert.Equal(expected.Longitude, actual.Longitude);
        }
    }
}
