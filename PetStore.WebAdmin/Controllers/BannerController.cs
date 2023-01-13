using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerApiClient _bannerApiClient;
        private readonly IFileBannerApiClient _fileBannerApiClient;

        public BannerController(IBannerApiClient bannerApiClient,
            IFileBannerApiClient fileBannerApiClient)
        {
            _bannerApiClient = bannerApiClient;
            _fileBannerApiClient = fileBannerApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new BannerSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _bannerApiClient.GetPaging(request);
            foreach (var item in data.Data.Items)
            {
                if (item.TypeBanner == "10")
                {
                    item.TypeBannerName = "Trang chủ";
                }
                if (item.TypeBanner == "20")
                {
                    item.TypeBannerName = "SPECIAL OFFER";
                }
            }

            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return ViewComponent("CreateBanner");
        }

        [HttpPost]
        public async Task<IActionResult> Create(BannerModel request)
        {
            request.Id = Guid.NewGuid();
            request.Image = request.Id.ToString();
            var result = await _fileBannerApiClient.CreateBanner(request);
            if (result.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.BannerId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                await _fileBannerApiClient.CreateImage(filemodels, (Guid)request.Id);

                TempData["success"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _bannerApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new BannerModel()
                {
                    Id = id,
                    Content = model.Content,
                    Title = model.Title,
                    Image = model.Image,
                    TypeBanner = model.TypeBanner,
                    AvailableTypeBanner= model.AvailableTypeBanner,
                    FilesModels = await _fileBannerApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("EditBanner", updateRequest);
            }
            return RedirectToAction("Index", "Banner");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BannerModel request)
        {
            var result = await _fileBannerApiClient.EditBanner(request);
            if (result.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.BannerId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                //delete files
                await _fileBannerApiClient.DeleteFiles((Guid)request.Id);
                //update files
                await _fileBannerApiClient.UpdateImage(filemodels, (Guid)request.Id);

                TempData["info"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bannerApiClient.DeletesAsync(id);

            await _fileBannerApiClient.DeleteFiles(id);
            await _fileBannerApiClient.DeleteDataFiles(id);

            if (result.Data > 0)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _bannerApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new BannerModel()
                {
                    Id = id,
                    Content = model.Content,
                    Title = model.Title,
                    Image = model.Image,
                    TypeBanner = model.TypeBanner,
                    AvailableTypeBanner = model.AvailableTypeBanner,
                    FilesModels = await _fileBannerApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("DetailBanner", detailRequest);
            }
            return RedirectToAction("Index", "Banner");
        }
    }
}