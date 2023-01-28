using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetStore.Common.System;
using PetStore.Common.XBaseModel;
using PetStore.Model;
using System.Net.Http.Headers;
using System.Text;

namespace PetStore.ApiClient
{
    public class ProductDetailApiClient : IProductDetailApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductDetailApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<int>> CreateProductDetail(ProductModel request)
        {
            var requestContent = new MultipartFormDataContent();

            if (request.filesadd != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.filesadd.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.filesadd.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "filesadd", request.filesadd.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Id.ToString()) ? "" : request.Id.ToString()), "Id");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Image) ? "" : request.Image), "Image");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content), "Content");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VoteId.ToString()) ? "" : request.VoteId.ToString()), "VoteId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Qualyti.ToString()) ? "" : request.Qualyti.ToString()), "Qualyti");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PriceDetail.ToString()) ? "" : request.PriceDetail.ToString()), "PriceDetail");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/ProductDetail/Create-ProductDetail", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(body);
            }
            throw new Exception(body);
        }

        public async Task<ApiResult<int>> EditProductDetail(ProductModel request)
        {
            var requestContent = new MultipartFormDataContent();

            if (request.filesadd != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.filesadd.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.filesadd.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "filesadd", request.filesadd.FileName);
            }
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Id.ToString()) ? "" : request.Id.ToString()), "Id");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Image) ? "" : request.Image), "Image");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content), "Content");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VoteId.ToString()) ? "" : request.VoteId.ToString()), "VoteId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Qualyti.ToString()) ? "" : request.Qualyti.ToString()), "Qualyti");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PriceDetail.ToString()) ? "" : request.PriceDetail.ToString()), "PriceDetail");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/ProductDetail/Update-ProductDetail", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(body);
            }
            throw new Exception(body);
        }
    }
}