using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.IO;
using FaceApiFresh.Util;
using System.Threading.Tasks;

namespace FaceApiFresh.Detection
{
    public class FaceIdentify
    {                                
        public static async Task<string> IdentifyTheFace()
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                var uri = AppUtil.ApiUri + "identify?" + queryString;

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{ \"personGroupId\": \"nihar_sarkar\",\"faceIds\": [\"df9ffea2-f1e6-405d-99fd-c368ee236547\"],\"maxNumOfCandidatesReturned\": 1,\"confidenceThreshold\": 0.5}");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync();
                    return JsonUtil.ResponseToJsonFormating(string.IsNullOrEmpty(contentString) ? response.ReasonPhrase : contentString);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static async Task<string> DetectFaceByMemoryStream(string imgPath)
        {
            try
            {
                // Request headers
                var client = new HttpClient(); var queryString = HttpUtility.ParseQueryString(string.Empty);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                // Request parameters
                queryString["returnFaceId"] = "true";
                queryString["returnFaceLandmarks"] = "false";
                var uri = AppUtil.ApiUri + "detect?" + queryString;

                HttpResponseMessage response;

                // Request body
                byte[] byteData = ImageStream.GetImageAsByteArray(imgPath);


                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync();
                    return JsonUtil.ResponseToJsonFormating(contentString);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}


