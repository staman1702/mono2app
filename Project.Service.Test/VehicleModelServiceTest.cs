using Moq;
using Project.Common;
using Project.Model;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.Service.Test
{
    public class VehicleModelServiceTest
    {
        [Fact]
        public async Task ListAllModelsAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();

            var mockMoRepo = new Mock<IVehicleModelRepository>();
            mockMoRepo.Setup(repo => repo.ListModelAsync())
                .ReturnsAsync(GetTestModels());
            var modelService = new VehicleModelService(mockMoRepo.Object, mockUoW.Object);

            // Act
            var result = await modelService.ListAllAsync();

            // Assert 
            mockMoRepo.Verify(x => x.ListModelAsync(), Times.Once());

            var model = Assert.IsAssignableFrom<IEnumerable<VehicleModel>>(
                result);
            Assert.Equal(2, model.Count());
        }

        private List<VehicleModel> GetTestModels()
        {
            var models = new List<VehicleModel>();
            models.Add(new VehicleModel()
            {
                Id = Guid.Parse("1f368f88-3dbf-4291-8128-058192265ad3"),
                Name = "Golf 3",
                Abrv = "G3",
                VehicleMakeId = Guid.Parse("2ca5ebe0-9b49-11e9-b475-0800200c9a66")
            });
            models.Add(new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            });
            return models;
        }

        [Fact]
        public async Task SaveModelsAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var newModel = new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            };

            var mockMoRepo = new Mock<IVehicleModelRepository>();
            mockMoRepo.Setup(repo => repo.AddModelAsync(newModel));
            var modelService = new VehicleModelService(mockMoRepo.Object, mockUoW.Object);

            // Act
            var result = await modelService.SaveAsync(newModel);

            // Assert             
            mockMoRepo.Verify(x => x.AddModelAsync(newModel), Times.Once());

            Assert.IsAssignableFrom<VehicleResponse<VehicleModel>>(result);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task FindMakeAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var testModel = new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            };

            var mockMoRepo = new Mock<IVehicleModelRepository>();
            mockMoRepo.Setup(repo => repo.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")))
            .ReturnsAsync(testModel);
            var modelService = new VehicleModelService(mockMoRepo.Object, mockUoW.Object);

            // Act
            var result = await modelService.FindModelAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"));

            // Assert             
            mockMoRepo.Verify(x => x.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")),
                Times.Once());
            Assert.Equal("x3", result.Name);
            Assert.IsAssignableFrom<VehicleModel>(result);

        }

        [Fact]
        public async Task UpdateAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var testModel = new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            };

            var updateModel = new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3-2",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            };


            var mockMoRepo = new Mock<IVehicleModelRepository>();

            mockMoRepo.Setup(repo => repo.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")))
            .ReturnsAsync(testModel);
            mockMoRepo.Setup(repo => repo.UpdateModelAsync(testModel));

            var modelService = new VehicleModelService(mockMoRepo.Object, mockUoW.Object);

            // Act

            var result = await modelService.UpdateAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"), updateModel);

            // Assert        
            mockMoRepo.Verify(x => x.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")),
                            Times.Once());
            mockMoRepo.Verify(x => x.UpdateModelAsync(testModel),
                Times.Once());

            Assert.IsAssignableFrom<VehicleResponse<VehicleModel>>(result);
            Assert.Equal("x3-2", testModel.Name);
            Assert.True(result.Success);

        }

        [Fact]
        public async Task DeleteAsync_Test()
        {
            // Arrange
            var mockUoW = new Mock<IUnitOfWork>();
            var testModel = new VehicleModel()
            {
                Id = Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"),
                Name = "x3",
                Abrv = "X3",
                VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66")
            };

            var mockMoRepo = new Mock<IVehicleModelRepository>();

            mockMoRepo.Setup(repo => repo.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")))
            .ReturnsAsync(testModel);
            mockMoRepo.Setup(repo => repo.RemoveModelAsync(testModel));

            var makeService = new VehicleModelService(mockMoRepo.Object, mockUoW.Object);

            // Act
            var result = await makeService.DeleteAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2"));

            // Assert        
            mockMoRepo.Verify(x => x.FindModelByIdAsync(Guid.Parse("1588a4c0-2b91-45d7-9197-83860e5252d2")),
                            Times.Once());
            mockMoRepo.Verify(x => x.RemoveModelAsync(testModel),
                Times.Once());

            Assert.IsAssignableFrom<VehicleResponse<VehicleModel>>(result);

            Assert.True(result.Success);

        }
    }
}
