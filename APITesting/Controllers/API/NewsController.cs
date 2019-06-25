using APITesting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace APITesting.Controllers.API
{
    public class NewsController : ApiController
    {
        //GET : /api/news
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTests()
        {
            Test test = new Test();
            test.Completed = true;
            test.ID = 527368;
            test.Title = "Yolo Solo";
            test.DueDate = DateTime.Now;

            string json = JsonConvert.SerializeObject(test);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://fakerestapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/activities", json);
                if (response.IsSuccessStatusCode)
                {
                    return Ok(JsonConvert.DeserializeObject(json));
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return Ok();
                }
            }
        }
    }
}
