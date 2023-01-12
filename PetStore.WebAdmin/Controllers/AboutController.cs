using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutApiClient _aboutApiClient;
        private readonly IFileAboutApiClient _fileAboutApiClient;
        private readonly IAboutDetailApiClient _aboutDetailApiClient;

        public AboutController(IAboutApiClient aboutApiClient,
            IFileAboutApiClient fileAboutApiClient,
            IAboutDetailApiClient aboutDetailApiClient)
        {
            _aboutApiClient = aboutApiClient;
            _fileAboutApiClient = fileAboutApiClient;
            _aboutDetailApiClient = aboutDetailApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new AboutSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _aboutApiClient.GetPaging(request);
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
            return ViewComponent("CreateAbout");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutModel request)
        {
            request.Id = Guid.NewGuid();
            request.Image = request.Id.ToString();
            var result = await _fileAboutApiClient.CreateAbout(request);
            var aboutModel = new AboutDetailModel();
            aboutModel.contenDetail = request.ContenDetail;
            aboutModel.catagoryDetail = request.CatagoryDetail;
            aboutModel.aboutId = (Guid)request.Id;
            var aboutDetail = await _aboutDetailApiClient.Create(aboutModel);
            if (result.Data > 0 || aboutDetail.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.AboutId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                await _fileAboutApiClient.CreateImage(filemodels, (Guid)request.Id);

                TempData["success"] = $"{result.Message} - {aboutDetail.Message}";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _aboutApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new AboutModel()
                {
                    Id = id,
                    Content = model.Content,
                    Title = model.Title,
                    Image = model.Image,
                    AboutId = model.AboutId,
                    CatagoryDetail = model.CatagoryDetail,
                    ContenDetail = model.ContenDetail,
                    FilesModels = await _fileAboutApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("EditAbout", updateRequest);
            }
            return RedirectToAction("Index", "About");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AboutModel request)
        {
            var result = await _fileAboutApiClient.EditAbout(request);
            var aboutModel = new AboutDetailModel();
            aboutModel.contenDetail = request.ContenDetail;
            aboutModel.catagoryDetail = request.CatagoryDetail;
            aboutModel.aboutId = (Guid)request.Id;
            var aboutDetail = await _aboutDetailApiClient.Edit(aboutModel);
            if (result.Data > 0 || aboutDetail.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.AboutId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                //delete files
                await _fileAboutApiClient.DeleteFiles((Guid)request.Id);
                //update files
                await _fileAboutApiClient.UpdateImage(filemodels, (Guid)request.Id);

                TempData["info"] = $"{result.Message} - {aboutDetail.Message}";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _aboutApiClient.DeletesAsync(id);

            await _fileAboutApiClient.DeleteFiles(id);
            await _fileAboutApiClient.DeleteDataFiles(id);

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
            var result = await _aboutApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new AboutModel()
                {
                    Id = id,
                    Content = model.Content,
                    Title = model.Title,
                    Image = model.Image,
                    CatagoryDetail = model.CatagoryDetail,
                    ContenDetail = model.ContenDetail,
                    FilesModels = await _fileAboutApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("DetailAbout", detailRequest);
            }
            return RedirectToAction("Index", "About");
        }
    }
}