using log4net;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MyOneSignalDemo.Helpers;

namespace MyOneSignalDemo.Models
{
    public class OneSignalManager
    {
        readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly string APIKey = WebHelpers.ReadConfig("APIKey");

        public ServiceResponse Create(OneSignalModel model)
        {
            string ApiURL = WebHelpers.ReadConfig("CreateAppURL");
            var client = new RestClient(ApiURL);
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", WebHelpers.contentType);
            request.AddHeader("Authorization", APIKey);
            request.AddParameter("application/json", "{\"name\" : \"" + model.name + "\",\n\"apns_env\": \"production\",\n\"apns_p12\": \"asdsadcvawe223cwef...\",\n\"apns_p12_password\": \"FooBar\",\n\"organization_id\": \"SyedCo\",\n\"gcm_key\": \"a gcm push key\"}", ParameterType.RequestBody);
            IRestResponse response = null;
            ServiceResponse sR = null;
            try
            {
                response = client.Execute(request);
                if (IsValidResponse(response))
                {
                    sR = (ServiceResponse)response;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return sR;
        }

        public List<ServiceResponse> ViewApps(string appId = "")
        {
            string ApiURL = string.Empty;
            ApiURL = WebHelpers.ReadConfig("ViewAppURL");
            if (!String.IsNullOrEmpty(appId))
            {
                ApiURL = ApiURL + "/" + appId;
            }

            var client = new RestClient(ApiURL);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", WebHelpers.contentType);
            request.AddHeader("Authorization", APIKey);

            try
            {
                IRestResponse<List<ServiceResponse>> response = client.Execute<List<ServiceResponse>>(request);
                return response.Data;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }




        public bool Update(ServiceResponse model)
        {
            string ApiURL = string.Empty;
            ApiURL = WebHelpers.ReadConfig("UpdateAppURL");
            bool isUpdated = false;

            if (!String.IsNullOrEmpty(model.id))
            {
                ApiURL = ApiURL + "/" + model.id;
            }
            var client = new RestClient(ApiURL);
            var request = new RestRequest(Method.PUT);

            request.AddHeader("Content-Type", WebHelpers.contentType);
            request.AddHeader("Authorization", APIKey);
            request.AddParameter("application/json", "{\"name\" : \"" + model.name + "\",\n\"apns_env\": \"production\",\n\"apns_p12\": \"asdsadcvawe223cwef...\",\n\"apns_p12_password\": \"FooBar\",\n\"organization_id\": \"c7896285-cc22-449d-bdba-18c7808bee2a\",\n\"gcm_key\": \"a gcm push key\"}", ParameterType.RequestBody);
            IRestResponse response = null;
            try
            {
                response = client.Execute<ServiceResponse>(request);

                var appDetails = ViewApps(model.id);
                if (appDetails != null)
                {
                    isUpdated = appDetails.FirstOrDefault(x => x.name == model.name) != null;

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return isUpdated;
        }



        private bool IsValidResponse(IRestResponse response)
        {
            bool isFailed = false;
            if (response != null)
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;

            return isFailed;
        }

    }
}