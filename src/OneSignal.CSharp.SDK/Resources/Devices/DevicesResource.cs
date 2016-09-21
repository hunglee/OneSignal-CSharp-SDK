﻿using RestSharp;

namespace OneSignal.CSharp.SDK.Resources.Devices
{
    public class DevicesResource : BaseResource, IDevicesResource
    {
        public DevicesResource(string apiKey, string apiUri) : base(apiKey, apiUri)
        {
        }

        public DeviceAddResult Add(DeviceAddOptions options)
        {
            RestRequest restRequest = new RestRequest("players", Method.POST);

            restRequest.AddHeader("Authorization", string.Format("Basic {0}", base.ApiKey));
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(options);

            IRestResponse<DeviceAddResult> restResponse = base.RestClient.Execute<DeviceAddResult>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            return restResponse.Data;
        }
    }
}