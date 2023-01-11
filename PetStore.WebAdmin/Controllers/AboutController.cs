using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutApiClient _aboutApiClient;
        private readonly IFileAboutApiClient _fileAboutApiClient;

        public AboutController(IAboutApiClient aboutApiClient,
            IFileAboutApiClient fileAboutApiClient)
        {
            _aboutApiClient = aboutApiClient;
            _fileAboutApiClient = fileAboutApiClient;
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

            if (result.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.AboutId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                await _fileAboutApiClient.CreateImage(filemodels, (Guid)request.Id);

                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}