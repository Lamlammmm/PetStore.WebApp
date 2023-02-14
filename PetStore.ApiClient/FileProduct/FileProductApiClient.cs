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
    public class FileProductApiClient : IFileProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileProductApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DeleteDataFiles(Guid id)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/FilesProduct/delete?id={id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(body);

            return JsonConvert.DeserializeObject<bool>(body);
        }

        public async Task<ApiResult<int>> CreateProduct(ProductModel request)
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name), "Name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Price.ToString()) ? "" : request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ImageDetail) ? "" : request.ImageDetail), "ImageDetail");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VoteId.ToString()) ? "" : request.VoteId.ToString()), "VoteId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PriceDetail.ToString()) ? "" : request.PriceDetail.ToString()), "PriceDetail");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Qualyti.ToString()) ? "" : request.Qualyti.ToString()), "Qualyti");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/Product/Create-Product", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(body);
            }
            throw new Exception(body);
        }

        public async Task<bool> CreateImage(FilesModel request, Guid id)
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/FilesProduct/create-image?id=" + id + "", requestContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFiles(Guid id)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/FilesProduct/delete-files?id={id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(body);

            return JsonConvert.DeserializeObject<bool>(body);
        }

        public async Task<ApiResult<int>> EditProduct(ProductModel request)
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name), "Name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Price.ToString()) ? "" : request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ImageDetail) ? "" : request.ImageDetail), "ImageDetail");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.VoteId.ToString()) ? "" : request.VoteId.ToString()), "VoteId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.PriceDetail.ToString()) ? "" : request.PriceDetail.ToString()), "PriceDetail");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Qualyti.ToString()) ? "" : request.Qualyti.ToString()), "Qualyti");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/Product/Update-Product", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(body);
            }
            throw new Exception(body);
        }

        public async Task<List<FilesModel>> GetFilesAdmin(Guid id)
        {
            var data = await GetListAsync<FilesModel>($"/api/FilesProduct/admin/{id}");
            return data;
        }

        public async Task<List<T>> GetListAsync<T>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }

        public async Task<bool> UpdateImage(FilesModel request, Guid id)
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.ProductId.ToString()) ? "" : request.ProductId.ToString()), "ProductId");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.PostAsync("/api/FilesProduct/update-image?id=" + id + "", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}