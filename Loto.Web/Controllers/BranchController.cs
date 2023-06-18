using Loto.Web.ApiServices.Interfaces;
using Loto.Web.Models.Requests;
using Loto.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Loto.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchApiService branchApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<BranchController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();

        public BranchController(IBranchApiService branchApiService,
                                IConfiguration configuration,
                                ILogger<BranchController> logger)
        {
            this.branchApiService = branchApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            BranchListResponse list = new BranchListResponse();
            try
            {
                list = await this.branchApiService.GetBranchList();
                //using(var httpclient=new HttpClient(this.clientHandler))
                //{
                //    var response = await httpclient.GetAsync("http://localhost:5048/api/Branch");
                //    if (response != null)
                //    {
                //        string resp= await response.Content.ReadAsStringAsync();
                //        list=JsonConvert.DeserializeObject<BranchListResponse>(resp);
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }
            return View(list.data);
        }

        // GET: BranchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BranchSaveRequest branch)
        {
            try
            {
                var result = await this.branchApiService.SaveBranch(branch);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View();
            }
         
        }

        public async Task<ActionResult> Groups()
        {
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {

            var itemGet = await this.branchApiService.GetBranch(id);

            BranchSaveRequest productSave = new BranchSaveRequest()
            {
                id = itemGet.data.Id,
                group = itemGet.data.Group,
                code = itemGet.data.Code,
                name = itemGet.data.Name,   
                address = itemGet.data.Address,
                phone = itemGet.data.Phone,
                collector   = itemGet.data.Collector,
                maxLottery = itemGet.data.MaxLottery,
                maxPhoneRecharge = itemGet.data.MaxPhoneRecharge,
                maxInvoices = itemGet.data.MaxInvoices,
                manager = itemGet.data.Manager,
                status = itemGet.data.Status,

            };


            return View(productSave);
        }


        // POST: BranchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BranchSaveRequest productSave)
        {
            try
            {

                await this.branchApiService.UpdateBranch(productSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete() {
            return View();
        }
        public async Task<ActionResult> Details(int Id) {
            BranchGetResponse item = new BranchGetResponse();
            try
            {
                item = await this.branchApiService.GetBranch(Id);
                //using (var httpclient = new HttpClient(this.clientHandler))
                //{
                //    var response = await httpclient.GetAsync("http://localhost:5048/api/Branch/"+Id.ToString());
                //    if (response != null)
                //    {
                //        string resp = await response.Content.ReadAsStringAsync();
                //        item = JsonConvert.DeserializeObject<BranchGetResponse>(resp);
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }
            return View(item.data);
        }

    }
}
