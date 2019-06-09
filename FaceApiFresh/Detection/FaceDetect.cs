using System;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using FaceApiFresh.Util;
using System.Threading.Tasks;

namespace FaceApiFresh.Detection
{
    public class FaceDetect
    {                                   
        public static Exception ErrorMessage { get; set; }
        public static string ResponseMessage { get; set; }
        public FaceDetect(string imgPath)
        {
            MakeRequestByMemoryStream(imgPath);
        }

        public static async Task<string> MakeRequestByJsonRequest(string imgPath)
        {
            try
            {
                // Request headers
                var client = new HttpClient(); var queryString = HttpUtility.ParseQueryString(string.Empty);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                // Request parameters
                queryString["returnFaceId"] = "true";
                queryString["returnFaceLandmarks"] = "false";
                queryString["returnFaceAttributes"] = "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure";
                var uri = AppUtil.ApiUri + "detect?" + queryString;

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{ \"url\":\"https://1843magazine.static-economist.com/sites/default/files/styles/article-main-image-overlay/public/Musk-web.jpg\"}");


                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = await client.PostAsync(uri, content).ConfigureAwait(false);
                    string contentString = await response.Content.ReadAsStringAsync();
                    return  JsonUtil.ResponseToJsonFormating(contentString);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex;
                throw new Exception(ex.Message);
            }


        }
        public static async Task<string> MakeRequestByMemoryStream(string imgPath)
        {
            try
            {
                // Request headers
                var client = new HttpClient(); var queryString = HttpUtility.ParseQueryString(string.Empty);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AppUtil.ApiKey);

                // Request parameters
                queryString["returnFaceId"] = "true";
                queryString["returnFaceLandmarks"] = "false";
                queryString["returnFaceAttributes"] = "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure";
                var uri = AppUtil.ApiUri +"detect?" + queryString;

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
                ErrorMessage = ex;
                throw new Exception(ex.Message);
            }


        }
    }
}


