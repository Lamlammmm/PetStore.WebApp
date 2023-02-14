using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IFileProductApiClient _fileProductApiClient;

        public ProductController(IProductApiClient productApiClient,
            IFileProductApiClient fileProductApiClient)
        {
            _productApiClient = productApiClient;
            _fileProductApiClient = fileProductApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new ProductSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _productApiClient.GetPaging(request);
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
            return ViewComponent("CreateProduct");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel request)
        {
            request.Id = Guid.NewGuid();
            request.Image = request.Id.ToString();
            var result = await _fileProductApiClient.CreateProduct(request);
            if (result.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.ProductId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                await _fileProductApiClient.CreateImage(filemodels, (Guid)request.Id);

                TempData["success"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _productApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new ProductModel()
                {
                    Id = id,
                    Content = model.Content,
                    Image = model.Image,
                    ProductId = model.ProductId,
                    ImageDetail = model.ImageDetail,
                    Name = model.Name,
                    Price = model.Price,
                    PriceDetail = model.PriceDetail,
                    Qualyti = model.Qualyti,
                    VoteId = model.VoteId,
                    AvailableVote = model.AvailableVote,
                    FilesModels = await _fileProductApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("EditProduct", updateRequest);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel request)
        {
            var result = await _fileProductApiClient.EditProduct(request);
            if (result.Data > 0)
            {
                var filemodels = new FilesModel();
                filemodels.ProductId = (Guid)request.Id;
                filemodels.filesadd = request.filesadd;
                //delete files
                await _fileProductApiClient.DeleteFiles((Guid)request.Id);
                //update files
                await _fileProductApiClient.UpdateImage(filemodels, (Guid)request.Id);

                TempData["info"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productApiClient.DeletesAsync(id);

            await _fileProductApiClient.DeleteFiles(id);
            await _fileProductApiClient.DeleteDataFiles(id);

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
            var result = await _productApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new ProductModel()
                {
                    Id = id,
                    Content = model.Content,
                    Image = model.Image,
                    ImageDetail = model.ImageDetail,
                    Name = model.Name,
                    Price = model.Price,
                    PriceDetail = model.PriceDetail,
                    ProductId = model.ProductId,
                    Qualyti = model.Qualyti,
                    VoteId = model.VoteId,
                    AvailableVote = model.AvailableVote,
                    FilesModels = await _fileProductApiClient.GetFilesAdmin(id)
                };
                return ViewComponent("DetailProduct", detailRequest);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}