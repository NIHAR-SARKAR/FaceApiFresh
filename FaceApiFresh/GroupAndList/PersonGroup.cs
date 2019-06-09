using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using FaceApiFresh.Util;

namespace FaceApiFresh.GroupAndList
{
    public static class PersonGroup
    {
        public static async Task<string> CreatePersonGroup()
        {
            try
            {

                var client = new HttpClient();

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                var uri = AppUtil.ApiUri + "persongroups/nihar_sarkar";

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \"Nihar Sarkar\", \"userData\": \"My first Person Group\",\"recognitionModel\": \"recognition_02\"}");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PutAsync(uri, content).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync();
                    return JsonUtil.ResponseToJsonFormating(string.IsNullOrEmpty(contentString) ? response.ReasonPhrase : contentString);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static async Task<string> AddFaceToPersonGroup(string imgPath)
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                // Request parameters
                queryString["userData"] = "Nihar Sarkar Image 1";
                var uri = AppUtil.ApiUri + "persongroups/nihar_sarkar/persons/ca464895-7b18-4a88-b436-72b1cf5fc620/persistedFaces?" + queryString;

                HttpResponseMessage response;

                // Request body
                byte[] byteData = ImageStream.GetImageAsByteArray(imgPath);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
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

        public static async Task<string> CreateForPersonGroup(string imgPath)
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                var uri = AppUtil.ApiUri + "persongroups/nihar_sarkar/persons";

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{\"url\":\"http://niharsarkar.in/images/gallery/nihar5.jpg\",\"name\": \"Nihar Sarkar\",\"userData\": \"Nihar Sarkar Image 1\"}");

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

        public static async Task<string> TrainPersonGroup()
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                var uri = AppUtil.ApiUri + "persongroups/nihar_sarkar/train";

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{}");

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
    }
}