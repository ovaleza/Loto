using Loto.Web.ApiServices.Interfaces;
using Loto.Web.Models;
using Loto.Web.Models.Requests;
using Loto.Web.Models.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Loto.Web.ApiServices.Services
{
    public class BranchApiService : IBranchApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<BranchApiService> logger;
        private string baseUrl;
        public BranchApiService(IHttpClientFactory clientFactory,
                                IConfiguration configuration, ILogger<BranchApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["Apiconfig:urlBase"];
        }

        public async Task<BranchGetResponse> GetBranch(int id)
        {
            BranchGetResponse item = new BranchGetResponse();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $"{this.baseUrl}/Branch/{id}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            item = JsonConvert.DeserializeObject<BranchGetResponse>(resp);
                        }
                    } 
                }

            }
            catch (Exception ex)
            {
                item.success = false;
                item.message = this.configuration["ErrorMessages:Get"];
                this.logger.LogError(item.message, ex.ToString());
            }
            return item;
        }

        public async Task<BranchListResponse> GetBranchList()
        {
            BranchListResponse list = new BranchListResponse() ;
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $"{this.baseUrl}/Branch";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            list = JsonConvert.DeserializeObject<BranchListResponse>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                list.success = false;
                list.message = this.configuration["ErrorMessages:GetList"];
                this.logger.LogError(list.message, ex.ToString());
            }
            return list;
        }

        public async Task<BranchAddResponse> SaveBranch(BranchSaveRequest branch)
        {
            BranchAddResponse result = new BranchAddResponse() ;
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $"{this.baseUrl}/Branch/SaveBranch";
                    StringContent request = new StringContent(JsonConvert.SerializeObject(branch), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url,request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<BranchAddResponse>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = this.configuration["ErrorMessages:Save"];
                this.logger.LogError(result.message, ex.ToString());
            }
            return result; 
        }

        public async Task<ResponseBase> UpdateBranch(BranchSaveRequest branchRequest)
        {
            ResponseBase result = new ResponseBase();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Branch/UpdateBranch";

                    StringContent request = new StringContent(JsonConvert.SerializeObject(branchRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ResponseBase>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ErrorMessages:Save"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }
    }
}
