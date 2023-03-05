using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Enums;
using System.Text;
using System.Text.Json;
using Teleperformance.FinalProject.Tests;
using Xunit;

namespace FinalProject.Test.IntegrationTests
{
    public class ProductsControllerTest : IClassFixture<FakeApplication>
    {
        private readonly HttpClient _httpClient;
        public ProductsControllerTest(FakeApplication factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async void ProductCrudProcess()
        {
            //GET****************
            GetAllProductByCategoryQueryRequest RequestGet = new GetAllProductByCategoryQueryRequest()
            {
                CategoryId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c")
            };
            HttpResponseMessage responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            string contentGet = await responseGet.Content.ReadAsStringAsync();
            BaseResponse<List<ProductQueryDto>> commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductQueryDto>>>(contentGet);
            List<ProductQueryDto> list = commentGet.Response;
            Assert.NotNull(list);
            int firstCount = list.Count();

            //CREATE****************
            CreateProductCommandRequest createRequest = new CreateProductCommandRequest()
            {
                CategoryId = RequestGet.CategoryId,
                MeasurementType = MeasurementType.Piece,
                Name = "asd",
                Quantity = 2
            };
            var bodyCreate = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseCreate = await _httpClient.PostAsync("/api/products", bodyCreate);
            responseCreate.EnsureSuccessStatusCode();
            string contentCreate = await responseCreate.Content.ReadAsStringAsync();
            BaseResponse<ProductCreateDto> commentCreate = JsonSerializer.Deserialize<BaseResponse<ProductCreateDto>>(contentCreate);
            Assert.NotNull(commentCreate);
            Assert.NotNull(commentCreate.Message);
            Assert.True(commentCreate.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductQueryDto>>>(contentGet);
            List<ProductQueryDto> list2 = commentGet.Response;
            Assert.NotNull(list2);
            int afterCreationCount = list2.Count();
            Assert.True((afterCreationCount - 1) == firstCount);

            //GETBYID**************
            HttpResponseMessage responseGetById = await _httpClient.GetAsync($"/api/products/{list2[0].Id}");
            responseGetById.EnsureSuccessStatusCode();
            string contentGetById = await responseGetById.Content.ReadAsStringAsync();
            BaseResponse<ProductQueryDto> commentGetById = JsonSerializer.Deserialize<BaseResponse<ProductQueryDto>>(contentGetById);
            Assert.NotNull(commentGetById.Response);


            //UPDATE****************
            UpdateProductCommandRequest updateRequest = new UpdateProductCommandRequest()
            {
                Id = list2[0].Id,
                IsPurchased = false,
                MeasurementType = MeasurementType.Liter,
                Name = "nametest",
                Quantity = 3,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var bodyUpdate = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseUpdate = await _httpClient.PutAsync("/api/products", bodyUpdate);
            responseUpdate.EnsureSuccessStatusCode();
            string contentUpdate = await responseUpdate.Content.ReadAsStringAsync();
            BaseResponse<ProductUpdateDto> commentUpdate = JsonSerializer.Deserialize<BaseResponse<ProductUpdateDto>>(contentUpdate);
            Assert.NotNull(commentUpdate);
            Assert.NotNull(commentUpdate.Message);
            Assert.True(commentUpdate.Success);


            //DELETE****************
            HttpResponseMessage responseDelete = await _httpClient.DeleteAsync($"/api/products/{list2[0].Id}");
            responseDelete.EnsureSuccessStatusCode();
            string contentDelete = await responseDelete.Content.ReadAsStringAsync();
            BaseResponse<object> commentDelete = JsonSerializer.Deserialize<BaseResponse<object>>(contentDelete);
            Assert.NotNull(commentDelete);
            Assert.NotNull(commentDelete.Message);
            Assert.True(commentDelete.Success);


            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductQueryDto>>>(contentGet);
            Assert.NotNull(commentGet.Response);
            int lastCount = commentGet.Response.Count();

            Assert.True(lastCount == firstCount);
        }
    }
}

