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
    public class FaceList
    {
        public static async Task<string> CreateFaceList()
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);
                string faceListId = "facelist_test"; // + DateTime.Now.Day.ToString()+"_"+ DateTime.Now.Month.ToString()
                queryString["faceListId"] = faceListId;

                var uri = AppUtil.ApiUri+"facelists/" + faceListId;


                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \""+ faceListId + "\",\"userData\": \"User-provided data attached to the face list.\",\"recognitionModel\": \"recognition_02\"}");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PutAsync(uri, content).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync();
                    return JsonUtil.ResponseToJsonFormating(string.IsNullOrEmpty(contentString)?response.ReasonPhrase: contentString);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public static async Task<string> AddfaceToFaceList(string imgPath)
        {
            try
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                // Request parameters
                queryString["userData"] = "Nihar Sarkar" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString();
                var uri = AppUtil.ApiUri + "facelists/facelist_test/persistedFaces?" + queryString;

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


