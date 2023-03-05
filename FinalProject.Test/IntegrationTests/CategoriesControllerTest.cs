using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Wrappers.Base;
using System.Text;
using System.Text.Json;
using Teleperformance.FinalProject.Tests;
using Xunit;

namespace FinalProject.Test.IntegrationTests
{
    public class CategoriesControllerTest : IClassFixture<FakeApplication>
    {

        private readonly HttpClient _httpClient;
        public CategoriesControllerTest(FakeApplication factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async void ProductCrudProcess()
        {
            //GET****************
            GetAllCategoryByShopListQueryRequest RequestGet = new GetAllCategoryByShopListQueryRequest()
            {
                ShopListId = Guid.Parse("12345678-48df-402d-99cb-5339467f923c")
            };
            HttpResponseMessage responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            string contentGet = await responseGet.Content.ReadAsStringAsync();
            BaseResponse<List<CategoryQueryDto>> commentGet = JsonSerializer.Deserialize<BaseResponse<List<CategoryQueryDto>>>(contentGet);
            List<CategoryQueryDto> list = commentGet.Response;
            Assert.NotNull(list);
            int firstCount = list.Count();

            //CREATE****************
            CreateCategoryCommandRequest createRequest = new CreateCategoryCommandRequest()
            {
                Name = "asdf",
                ShopListId = RequestGet.ShopListId
            };
            var bodyCreate = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseCreate = await _httpClient.PostAsync("/api/categories", bodyCreate);
            responseCreate.EnsureSuccessStatusCode();
            string contentCreate = await responseCreate.Content.ReadAsStringAsync();
            BaseResponse<CategoryCreateDto> commentCreate = JsonSerializer.Deserialize<BaseResponse<CategoryCreateDto>>(contentCreate);
            Assert.NotNull(commentCreate);
            Assert.NotNull(commentCreate.Message);
            Assert.True(commentCreate.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<CategoryQueryDto>>>(contentGet);
            List<CategoryQueryDto> list2 = commentGet.Response;
            Assert.NotNull(list2);
            int afterCreationCount = list2.Count();
            Assert.True((afterCreationCount - 1) == firstCount);

            //GETBYID**************
            HttpResponseMessage responseGetById = await _httpClient.GetAsync($"/api/categories/{list2[0].Id}");
            responseGetById.EnsureSuccessStatusCode();
            string contentGetById = await responseGetById.Content.ReadAsStringAsync();
            CategoryQueryDto commentGetById = JsonSerializer.Deserialize<CategoryQueryDto>(contentGetById);
            Assert.NotNull(commentGetById);

            //UPDATE****************
            UpdateCategoryCommandRequest updateRequest = new UpdateCategoryCommandRequest()
            {
                Id = list2[0].Id,
                Name = "UpdatedTestName"
            };
            var bodyUpdate = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseUpdate = await _httpClient.PutAsync("/api/categories", bodyUpdate);
            responseUpdate.EnsureSuccessStatusCode();
            string contentUpdate = await responseUpdate.Content.ReadAsStringAsync();
            BaseResponse<CategoryUpdateDto> commentUpdate = JsonSerializer.Deserialize<BaseResponse<CategoryUpdateDto>>(contentUpdate);
            Assert.NotNull(commentUpdate);
            Assert.NotNull(commentUpdate.Message);
            Assert.True(commentUpdate.Success);

            //DELETE****************
            HttpResponseMessage responseDelete = await _httpClient.DeleteAsync($"/api/categories/{list2[0].Id}");
            responseDelete.EnsureSuccessStatusCode();
            string contentDelete = await responseDelete.Content.ReadAsStringAsync();
            BaseResponse<object> commentDelete = JsonSerializer.Deserialize<BaseResponse<object>>(contentDelete);
            Assert.NotNull(commentDelete);
            Assert.NotNull(commentDelete.Message);
            Assert.True(commentDelete.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<CategoryQueryDto>>>(contentGet);
            Assert.NotNull(commentGet.Response);
            int lastCount = commentGet.Response.Count();

            Assert.True(lastCount == firstCount);
        }
    }
}
