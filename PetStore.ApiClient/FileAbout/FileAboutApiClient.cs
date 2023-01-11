using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetStore.Common.System;
using PetStore.Common.XBaseModel;
using PetStore.Model;
using System.Net.Http.Headers;

namespace PetStore.ApiClient
{
    public class FileAboutApiClient : IFileAboutApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileAboutApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<int>> CreateAbout(AboutModel request)
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Title) ? "" : request.Title), "Title");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Image) ? "" : request.Image), "Image");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content), "Content");

            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/About/Create-About", requestContent);
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.AboutId.ToString()) ? "" : request.AboutId.ToString()), "AboutId");
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.PostAsync("/api/FilesAbout/create-image?id=" + id + "", requestContent);

            return response.IsSuccessStatusCode;
        }
    }
}