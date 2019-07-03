using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;

namespace FaceApiFresh.Detection
{
    public class FaceVerify
    {
        static FaceVerify()
        {
            MakeRequest();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ecf94b980460460ca7b561b1bd0b7e9b");

            var uri = "https://westus.api.cognitive.microsoft.com/face/v1.0/verify?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("~/Images/IMG_0633.JPG");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

        }
    }
}


namespace CSHttpClientSample
{
    static class Program
    {
        
    }
}