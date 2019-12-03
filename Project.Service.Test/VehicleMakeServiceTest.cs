using Moq;
using Project.Common;
using Project.Model;
using Project.Repository.Common;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project.Service.Test
{
    public class VehicleMakeServiceTest
    {
        [Fact]
        public async Task ListAllAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            
            var mockRepo = new Mock<IVehicleMakeRepository>();
            mockRepo.Setup(repo => repo.ListMakeAsync())
                .ReturnsAsync(GetTestMakes());
            var makeService = new VehicleMakeService(mockRepo.Object, mockUoW.Object);

            // Act
            var result = await makeService.ListAllAsync();

            // Assert 
            mockRepo.Verify(x => x.ListMakeAsync(), Times.Once());

            var model = Assert.IsAssignableFrom<IEnumerable<VehicleMake>>(
                result);
            Assert.Equal(2, model.Count());
        }

        private List<VehicleMake> GetTestMakes()
        {
            var makes = new List<VehicleMake>();
            makes.Add(new VehicleMake()
            {
                Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"),
                Name = "TestWagen",
                Abrv = "TW"
            });
            makes.Add(new VehicleMake()
            {
                Id = Guid.Parse("2d6ac610-9b49-11e9-b475-1111200c9a99"),
                Name = "BmTest",
                Abrv = "BMT"
            });
            return makes;
        }

        [Fact]
        public async Task SaveAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var newMake = new VehicleMake()
            {
                Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"),
                Name = "TestWagen",
                Abrv = "TW"
            };

            var mockRepo = new Mock<IVehicleMakeRepository>();
            mockRepo.Setup(repo => repo.AddMakeAsync(newMake));
            var makeService = new VehicleMakeService(mockRepo.Object, mockUoW.Object);

            // Act
            var result = await makeService.SaveAsync(newMake);

            // Assert             
            mockRepo.Verify(x => x.AddMakeAsync(newMake), Times.Once());

            Assert.IsAssignableFrom<VehicleResponse<VehicleMake>>(result);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task FindMakeAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var testMake = new VehicleMake()
            {
                Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"),
                Name = "TestWagen",
                Abrv = "TW"
            };

            var mockRepo = new Mock<IVehicleMakeRepository>();
            mockRepo.Setup(repo => repo.FindMakeByIdAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99")))
            .ReturnsAsync(testMake);
            var makeService = new VehicleMakeService(mockRepo.Object, mockUoW.Object);

            // Act
            var result = await makeService.FindMakeAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"));

            // Assert             
            mockRepo.Verify(x => x.FindMakeByIdAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99")), 
                Times.Once());

            Assert.IsAssignableFrom<VehicleMake>(result);           

        }


        [Fact]
        public async Task DeleteAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var testMake = new VehicleMake()
            {
                Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"),
                Name = "TestWagen",
                Abrv = "TW"
            };

            var mockRepo = new Mock<IVehicleMakeRepository>();

            mockRepo.Setup(repo => repo.FindMakeByIdAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99")))
            .ReturnsAsync(testMake);
            mockRepo.Setup(repo => repo.DeleteMakeAsync(testMake));

            var makeService = new VehicleMakeService(mockRepo.Object, mockUoW.Object);

            // Act
            var result = await makeService.DeleteAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99"));

            // Assert        
            mockRepo.Verify(x => x.FindMakeByIdAsync(Guid.Parse("2ca5ebe0-9b49-11e9-b475-1111200c9a99")),
                            Times.Once());
            mockRepo.Verify(x => x.DeleteMakeAsync(testMake),
                Times.Once());

            Assert.IsAssignableFrom<VehicleResponse<VehicleMake>>(result);

            Assert.True(result.Success);

        }

    }
}
