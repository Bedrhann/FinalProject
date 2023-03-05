using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.Enums;
using Moq;
using Xunit;

namespace FinalProject.Test.UnitTests.ProductTests
{
    public class CreateProductCommandHandlerTest
    {
        [Fact]
        public async void CreateProduct_IsSuccess()
        {
            CreateProductCommandRequest productRequest = new CreateProductCommandRequest()
            {
                Name = "TestProduct",
                CategoryId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c"),
                MeasurementType = MeasurementType.Kg,
                Quantity = 2
            };
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                CategoryId = productRequest.CategoryId,
                IsPurchased = false,
                Quantity = 2,
                MeasurementType = MeasurementType.Kg,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var mockRepo = new Mock<IProductCommandService>();
            mockRepo.Setup(c => c.InsertAsync(It.IsAny<ProductCreateDto>())).ReturnsAsync(new BaseResponse<ProductCreateDto>(true));
            var command = new CreateProductCommandHandler(mockRepo.Object);

            BaseResponse<ProductCreateDto> response = await command.Handle(productRequest, CancellationToken.None);

            Assert.True(response.Success);
            Assert.NotNull(response.Message);

        }
        [Fact]
        public async void CreateProduct_IsFailDataRequest()
        {
            CreateProductCommandRequest productRequest = new CreateProductCommandRequest()
            {
                Name = "TestProduct",
                CategoryId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c"),
                MeasurementType = MeasurementType.Kg,
                Quantity = 2
            };
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                CategoryId = productRequest.CategoryId,
                IsPurchased = false,
                Quantity = 2,
                MeasurementType = MeasurementType.Kg,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var mockRepo = new Mock<IProductCommandService>();
            mockRepo.Setup(c => c.InsertAsync(It.IsAny<ProductCreateDto>())).ReturnsAsync(new BaseResponse<ProductCreateDto>(false));

            var command = new CreateProductCommandHandler(mockRepo.Object);

            BaseResponse<ProductCreateDto> response = await command.Handle(productRequest, CancellationToken.None);

            Assert.False(response.Success);

        }
    }
}
