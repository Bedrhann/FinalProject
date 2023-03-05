using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using Moq;
using Xunit;

namespace FinalProject.Test.UnitTests.CategoryTests
{
    public class CreateCategoryCommandHandlerTest
    {
        [Fact]
        public async void CreateCategory_IsSuccess()
        {
            CreateCategoryCommandRequest categoryRequest = new CreateCategoryCommandRequest()
            {
                Name = "TestCategory",
                ShopListId = Guid.NewGuid(),
            };
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                ShopListId = categoryRequest.ShopListId,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            var mockRepo = new Mock<ICategoryCommandService>();
            mockRepo.Setup(c => c.InsertAsync(It.IsAny<CategoryCreateDto>())).ReturnsAsync(new BaseResponse<CategoryCreateDto>(true));
            var command = new CreateCategoryCommandHandler(mockRepo.Object);

            BaseResponse<CategoryCreateDto> response = await command.Handle(categoryRequest, CancellationToken.None);
            Assert.True(response.Success);
            Assert.NotNull(response.Message);
        }

        [Fact]
        public async void CreateCategory_IsFailDataRequest()
        {
            CreateCategoryCommandRequest categoryRequest = new CreateCategoryCommandRequest()
            {
                Name = "TestCategory",
                ShopListId = Guid.NewGuid(),
            };
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                ShopListId = categoryRequest.ShopListId,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            var mockRepo = new Mock<ICategoryCommandService>();
            mockRepo.Setup(c => c.InsertAsync(It.IsAny<CategoryCreateDto>())).ReturnsAsync(new BaseResponse<CategoryCreateDto>(false));
            var command = new CreateCategoryCommandHandler(mockRepo.Object);

            BaseResponse<CategoryCreateDto> response = await command.Handle(categoryRequest, CancellationToken.None);
            Assert.False(response.Success);
        }
    }
}
